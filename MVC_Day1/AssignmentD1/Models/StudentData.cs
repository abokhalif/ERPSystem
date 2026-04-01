using System.Security.Cryptography.X509Certificates;

namespace AssignmentD1.Models
{
	public class StudentData
	{
		List<Student> students;

		public StudentData()
		{
			students = new List<Student>();
			students.Add(new Student() { Id = 1, Name = "Ali", Address = "Cairo", Image = "s1.jpeg" });
			students.Add(new Student() { Id = 2, Name = "Hamed", Address = "Minya", Image = "s1.jpeg" });
			students.Add(new Student() { Id = 3, Name = "Talal", Address = "El Reyad", Image = "s1.jpeg" });
			students.Add(new Student() { Id = 4, Name = "Taha", Address = "Assuit", Image = "s1.jpeg" });
			students.Add(new Student() { Id = 5, Name = "Jack", Address = "Dhobi", Image = "s1.jpeg" });

		}
		public Student GetStudentById(int id)=> students.FirstOrDefault(s => s.Id == id);
		public List<Student> GetAll() => students;
	}
}
