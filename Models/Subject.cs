using System.ComponentModel.DataAnnotations;

namespace Itmo.Mvc.StudentsJournal.Models
{
	public class Subject
	{
		public int id { get; set; }
		[Required(ErrorMessage = "Поле не может быть пустым")]
		[StringLength(50)]
		[Display(Name = "Предмет")]
		public string subjectName { get; set; } = null!;

		
	}
}
