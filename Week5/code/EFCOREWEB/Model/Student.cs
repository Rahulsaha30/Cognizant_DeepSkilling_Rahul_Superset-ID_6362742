using System.ComponentModel.DataAnnotations;
using EFCOREWEB.Model;

namespace EFCOREWEB.Model
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public List<Course> courses { get; set; } = new();

[Timestamp]
    public byte[] RowVerion { get; set; } = default!;
  }
}