using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itmo.Mvc.StudentsJournal.Models
{
	public class GradeLog
	{
		public int id { get; set; }
		[Required]
		[StringLength(50)]
		[Display(Name = "Предмет")]
		public string subjectName { get; set; } = null!;
		[Required(ErrorMessage = "Поле не может быть пустым")]
		[Range(1,5, ErrorMessage = "оценка от 1 до 5") ]
		[Display(Name = "Оценка")]
		public int grade { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.DateTime)]
		public DateTime date {  get; set; }
		
		public int? studentId { get; set; }
		[ForeignKey("studentId")]
		public Student? student { get; set; }

		
		
	}
}
