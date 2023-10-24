using System.Windows.Controls;

namespace Timetable
{
	public partial class MainWindow
	{
		// Проверяет, если в textBox ничего не написано, то кнопка не срабатывает
		private void tAudition_TextChanged(object sender, TextChangedEventArgs e)
		{
			bAudition.IsEnabled = !string.IsNullOrWhiteSpace(tAudition.Text);
		}

		private void tTeacher_TextChanged(object sender, TextChangedEventArgs e)
		{
			bTeacher.IsEnabled = !string.IsNullOrWhiteSpace(tTeacher.Text);
		}

		private void tDiscipline_TextChanged(object sender, TextChangedEventArgs e)
		{
			bDiscipline.IsEnabled = !string.IsNullOrWhiteSpace(tDiscipline.Text);
		}
	}
}