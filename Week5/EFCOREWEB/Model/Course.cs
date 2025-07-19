using EFCOREWEB.Model;

namespace EFCOREWEB.Model
{
  public class Course
  {
    public int Id{ get; set; }
    public string CourseName { get; set; } = String.Empty;

    public List<Student> students { get; set; } = new();
  }
}