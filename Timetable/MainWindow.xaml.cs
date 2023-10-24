using System.Windows;
using System.Windows.Controls;

namespace Timetable
{
	public partial class MainWindow

	{
		public MainWindow()
		{
			InitializeComponent();
		}

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

		private void AddAudienceClick(object sender, RoutedEventArgs e)
		{
			cbAudience.Items.Add(tAudition.Text.Trim());
			tAudition.Clear();
			bAudition.IsEnabled = false;
		}

		private void AddTeacherClick(object sender, RoutedEventArgs e)
		{
			cbTeacher.Items.Add(tTeacher.Text.Trim());
			tTeacher.Clear();
			bTeacher.IsEnabled = false;
		}

		private void AddDisciplineClick(object sender, RoutedEventArgs e)
		{
			cbDiscipline.Items.Add(tDiscipline.Text.Trim());
			tDiscipline.Clear();
			bDiscipline.IsEnabled = false;
		}

		private void onCreate(object sender, RoutedEventArgs e)
		{
			var audience = cbAudience.Text.Trim();
			var teacher = cbTeacher.Text.Trim();
			var discipline = cbDiscipline.Text.Trim();
			var pairNumber = timetable.Items.Count + 1;

			timetable.Items.Add(new TimetableRow(pairNumber, discipline, audience, teacher));

			cbAudience.SelectedIndex = -1;
			cbTeacher.SelectedIndex = -1;
			cbDiscipline.SelectedIndex = -1;
		}

		private void onRemove(object sender, RoutedEventArgs e)
		{
			if (timetable.SelectedItem == null)
			{
				return;
			}
			else
			{
				bRemove.IsEnabled = true;
			}

			for (var i = timetable.SelectedIndex; i < timetable.Items.Count; i++)
			{
				var row = (TimetableRow)timetable.Items[i];
				row.PairNumber = i;
			}

			timetable.Items.Remove(timetable.SelectedItem);
			timetable.Items.Refresh();
		}
	}
}