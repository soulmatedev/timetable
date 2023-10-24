namespace Timetable
{
	public class TimetableRow
	{
		public TimetableRow(int pairNumber, string discipline, string audition, string teacherName)
		{
			PairNumber = pairNumber;
			Discipline = discipline;
			Audition = audition;
			TeacherName = teacherName;
		}

		public int PairNumber { get; set; }
		private string Discipline { get; set; }
		private string Audition { get; set; }
		private string TeacherName { get; set; }

		public override string ToString()
		{
			return $"{PairNumber} - {Discipline} [{Audition}] ({TeacherName})";
		}
	}
}