using AssignmentD1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentD1.Controllers
{
	public class StudentController : Controller
	{
		StudentData StudentData = new StudentData();
		public IActionResult GetDetailsByID(int id)
		{
			Student student=StudentData.GetStudentById(id);
			return View("StudentDetails",student);
		}
		public IActionResult Index()
		{
			List<Student> Students=StudentData.GetAll(); 
			return View("AllStudents",Students);
		}
	}
}
