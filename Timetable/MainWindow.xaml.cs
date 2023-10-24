using System.Collections.Generic;
using System.Linq;
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


		// Не дает создать две одинаковые аудитории
		HashSet<string> audienceSet = new HashSet<string>();

		private void AddAudienceClick(object sender, RoutedEventArgs e)
		{
			var newAudience = tAudition.Text.Trim();

			// Проверить, есть ли уже такой элемент в HashSet
			if (!audienceSet.Contains(newAudience))
			{
				// Если нет, добавить его в HashSet и ComboBox
				audienceSet.Add(newAudience);
				cbAudience.Items.Add(newAudience);
			}

			tAudition.Clear();
		}

		private void AddTeacherClick(object sender, RoutedEventArgs e)
		{
			var teacher = tTeacher.Text.Trim();
			var words = teacher.Split(' ');

			// Проверить, что введено ровно 3 слова и каждое из них имеет минимум 2 символа
			if (words.Length == 3 && words.All(word => word.Length >= 2))
			{
				// Сделать первую букву каждого слова заглавной, остальные прописные
				teacher = string.Join(" ", words.Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

				// Проверить, есть ли уже такой элемент в ComboBox
				if (cbTeacher.Items.IndexOf(teacher) == -1)
				{
					// Если нет, добавить его
					cbTeacher.Items.Add(teacher);
				}
			}

			tTeacher.Clear();
		}

		HashSet<string> disciplineSet = new HashSet<string>();

		private void AddDisciplineClick(object sender, RoutedEventArgs e)
		{
			var newDiscipline = tDiscipline.Text.Trim();

			if (!disciplineSet.Contains(newDiscipline))
			{
				disciplineSet.Add(newDiscipline);
				cbDiscipline.Items.Add(newDiscipline);
			}

			tDiscipline.Clear();
		}

		private void onCreate(object sender, RoutedEventArgs e)
		{
			var audience = cbAudience.Text.Trim();
			var teacher = cbTeacher.Text.Trim();
			var discipline = cbDiscipline.Text.Trim();

			// Проверка, что все поля ComboBox заполнены
			if (string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(teacher) ||
			    string.IsNullOrWhiteSpace(discipline))
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