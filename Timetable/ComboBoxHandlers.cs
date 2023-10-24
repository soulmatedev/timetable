namespace Timetable
{
	public partial class MainWindow
	{
		private void AuditionCB()
		{
			if (tAudition.Text.Trim().Length <= 3)
			{
				bAudition.IsEnabled = true;
			}
		}

		private void TeacherCB()
		{
			if (tTeacher.Text.Trim().Length <= 10)
			{
				bTeacher.IsEnabled = true;
			}
		}

		private void DisciplineCB()
		{
			if (tDiscipline.Text.Trim().Length <= 10)
			{
				bDiscipline.IsEnabled = true;
			}
		}
	}
}