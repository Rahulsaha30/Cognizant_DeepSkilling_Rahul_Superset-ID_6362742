using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EFCOREWEB.Model
{
  public class User
  {
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;

    public string UserEmail { get; set; } = string.Empty;

    public string password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
  }
  
}