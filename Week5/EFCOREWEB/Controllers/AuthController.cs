using Microsoft.AspNetCore.Mvc;
using EFCOREWEB.Data;
using EFCOREWEB.DTO;
using EFCOREWEB.Helper;
using EFCOREWEB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace EFCOREWEB.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class AuthController : ControllerBase
  {

    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
      _context = context;
      _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
      if (await _context.Users.AnyAsync(u => u.UserEmail == userRegisterDto.UserEmail))
        return BadRequest("USER ALREADY EXIST");

      var user = new User
      {
        UserName = userRegisterDto.UserName,
        UserEmail = userRegisterDto.UserEmail,
        password = PasswordHash.Hash(userRegisterDto.password),
        Role = "User"
      };

      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return Ok("User Registeres");
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
      var hashed = PasswordHash.Hash(dto.password);

      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == dto.Email.ToLower()
      && u.password == hashed);

      if (user == null) return BadRequest("INVALID");

      var claims = new List<Claim>
      {
      new Claim(ClaimTypes.Name,user.UserEmail),
      new Claim("UserId",user.Id.ToString())
      };

      foreach (var role in user.Role.Split(','))
        claims.Add(new Claim(ClaimTypes.Role, role.Trim()));

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]!));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
         claims: claims,
         expires: DateTime.UtcNow.AddMinutes(30),
         signingCredentials: creds
     );

      return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    [HttpGet("User")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> GetAllUser()
    {
      var user = await _context.Users.ToListAsync();
      return Ok(user);
    }

    [HttpPut("upgrade-role/{userId}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> UpgradeRole(int userId, [FromBody] string NewRole)
    {
      var allowedRoles = new[] { "User","Admin","Manager"};
      if (!allowedRoles.Contains(NewRole)) return BadRequest("Invalid Role");
      var user = await _context.Users.FindAsync(userId);
      if (user == null) return NotFound();

      user.Role = NewRole;
      await _context.SaveChangesAsync();
      return Ok("Role upgraded");
    }
  }
}