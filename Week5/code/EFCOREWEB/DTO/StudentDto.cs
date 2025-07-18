namespace EFCOREWEB.DTO
{
  public class StudentDto()
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Courses { get; set; } = new();
  }
}