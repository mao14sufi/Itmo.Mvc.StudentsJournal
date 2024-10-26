using Itmo.Mvc.StudentsJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace Itmo.Mvc.StudentsJournal.Data
{
	public class StudentsJournalContext : DbContext
	{
		public StudentsJournalContext(DbContextOptions<StudentsJournalContext> options) : base(options) { }
		public DbSet<Student> Students { get; set; }
		public DbSet<GradeLog> GradeLogs { get; set; }

		public DbSet<Subject> Subjects { get; set; }

	}
}
