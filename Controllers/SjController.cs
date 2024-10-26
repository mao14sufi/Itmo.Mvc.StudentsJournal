using Itmo.Mvc.StudentsJournal.Data;
using Itmo.Mvc.StudentsJournal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Itmo.Mvc.StudentsJournal.Controllers
{
	public class SjController : Controller
	{
		private readonly StudentsJournalContext _context;

		public SjController(StudentsJournalContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var item =await  _context.GradeLogs.Include(s => s.student)
					   .ToListAsync();
			ViewBag.StudentGrades = GetStudentsGrades();

			ViewBag.FiveBestStudents = Get5BestStudents();
			ViewBag.FiveWorstStudents = Get5WorstStudents();

			return View(item);
		}

		public IActionResult Create()
		{
			ViewData["Students"] = new SelectList(_context.Students, "id", "Name");
			ViewData["Subjects"] = new SelectList(_context.Subjects,"" ,"subjectName");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("id,subjectName,grade,studentId")] GradeLog log)
		{

			ViewData["Students"] = new SelectList(_context.Students, "id", "Name");
			ViewData["Subjects"] = new SelectList(_context.Subjects, "", "subjectName");
			if (ModelState.IsValid)
			{
				_context.GradeLogs.Add(log);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(log);

		}

		public async Task<IActionResult> Edit(int id)
		{
			ViewData["Students"] = new SelectList(_context.Students, "id", "Name");
			ViewData["Subjects"] = new SelectList(_context.Subjects, "", "subjectName");
			var log = await _context.GradeLogs.FirstOrDefaultAsync(l => l.id == id);
			return View(log);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("id,subjectName,grade,studentId")] GradeLog log)
		{
			ViewData["Students"] = new SelectList(_context.Students, "id", "Name");
			ViewData["Subjects"] = new SelectList(_context.Subjects, "", "subjectName");
			if (ModelState.IsValid)
			{
				_context.GradeLogs.Update(log);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(log);

		}
		public async Task<IActionResult> Delete(int id)
		{
			
			var log =await _context.GradeLogs.Include(s => s.student)
				.FirstOrDefaultAsync(log => log.id == id);
			return View(log);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var log = await _context.GradeLogs.FindAsync(id);
			if (log != null)
			{
				_context.GradeLogs.Remove(log);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(log);
		}

		
		public async Task<IActionResult> WritetoFileBest()
		{
			var fiveBestStudents = Get5BestStudents();
			string path = "fiveBestStudents.txt";
			using (StreamWriter writer = new StreamWriter(path, false))
			{
				{
					foreach ((string,int) s in fiveBestStudents)
						writer.WriteLine(s);
				}
				
			}
			
			return Content("File created");
		}

		public async Task<IActionResult> WritetoFileWorst()
		{
			var fiveWorstStudents = Get5WorstStudents();
			string path = "fiveWorstStudents.txt";
			using (StreamWriter writer = new StreamWriter(path, false))
			{
				{
					foreach ((string, int) s in fiveWorstStudents)
						writer.WriteLine(s);
				}

			}

			return Content("File created");
		}
		public  List<(string,int)> GetStudentsGrades()
		{
			var students =  _context.Students.ToList();
			var totalgrades = new List<(string Name, int totalGrade)>();


			foreach (var student in students)
			{
				int totalgrade = 0;
				var gradeLog =  _context.GradeLogs.Where(l => l.studentId == student.id).ToList();

				foreach (var l in gradeLog)
				{
					totalgrade += l.grade;

				}
				totalgrades.Add((student.Name, totalgrade));
								
			}

						
			return totalgrades;

		}

		public List<(string, int)> Get5BestStudents()
		{
			var students = GetStudentsGrades();
			var fiveBestStudents = students.OrderByDescending(s => s.Item2).Take(5);
			return fiveBestStudents.ToList(); 
		}
		public List<(string, int)> Get5WorstStudents()
		{
			var students = GetStudentsGrades();
			var fiveBestStudents = students.OrderBy(s => s.Item2).Take(5);
			return fiveBestStudents.ToList();
		}

	}
}
