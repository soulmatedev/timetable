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
        
		private void AddAudienceClick(object sender, RoutedEventArgs e)
		{
			cbAudience.Items.Add(tAudition.Text.Trim());
			tAudition.Clear();
		}
		
		private void AddTeacherClick(object sender, RoutedEventArgs e)
		{
			cbTeacher.Items.Add(tTeacher.Text.Trim());
			tTeacher.Clear();
		}
		
		private void AddDisciplineClick(object sender, RoutedEventArgs e)
		{
			cbDiscipline.Items.Add(tDiscipline.Text.Trim());
			tDiscipline.Clear();
		}
        
		private void onCreate(object sender, RoutedEventArgs e)
		{
			var audience = cbAudience.Text.Trim();
			var teacher = cbTeacher.Text.Trim();
			var discipline = cbDiscipline.Text.Trim();

			// Проверить, что все поля ComboBox заполнены
			if (string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(teacher) || string.IsNullOrWhiteSpace(discipline))
			{
				return;
			}

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