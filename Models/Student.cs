using System.ComponentModel.DataAnnotations;

namespace Itmo.Mvc.StudentsJournal.Models
{
	public class Student
	{
		public int id { get; set; }
		[Required( ErrorMessage = "Поле не может быть пустым")]
		[StringLength(50)]
		[Display(Name = "Студент")]
		public string Name { get; set; } =null!;
		

		
		
		public List<GradeLog>? gradeLogs { get; set; }

		
	}
}
