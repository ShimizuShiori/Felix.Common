using Felix.Common;

namespace Felix.Tools
{
	public class ChooesForm<T> : Form
	{
		readonly IDictionary<string, T> _choices;
		string selectedKey = string.Empty;
		string filter = string.Empty;
		IList<Button> buttons;
		protected ChooesForm(IDictionary<string, T> choices)
		{
			this._choices = choices;
			buttons = new List<Button>();
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.AutoSize = true;
			this.TopMost = true;
			DrawButtons();
		}

		void DrawButtons()
		{
			this.Controls.Clear();
			this.buttons.Clear();
			var filteredChoices = _choices
				.Where(x => x.Key.ToLower().StartsWith(filter.ToLower()))
				.ToMap(x => (x.Key, x.Value));
			int count = filteredChoices.Count;
			var size = (int)Math.Ceiling(Math.Sqrt(count)) + 1;
			var keys = filteredChoices.Keys.OrderBy(x => x);
			int index = 0;
			bool over = false;
			for (int rowIndex = 0; rowIndex < size; rowIndex++)
			{
				for (int colIndex = 0; colIndex < size; colIndex++)
				{
					if (index == count)
					{
						DrawExitButton(rowIndex, colIndex);
						over = true;
					}
					if (over)
						break;
					DrawButton(filteredChoices, rowIndex, colIndex, keys, index++);
				}
				if (over)
					break;
			}
			this.buttons[0].Focus();
		}

		void DrawExitButton(int rowIndex, int colIndex)
		{
			var btn = new Button();
			btn.Width = 300;
			btn.Height = 300;
			btn.Left = colIndex * 300;
			btn.Top = rowIndex * 300;
			btn.Text = "Exit";
			btn.Font = new Font(btn.Font.FontFamily, 15);
			btn.ForeColor = Color.IndianRed;
			this.Controls.Add(btn);

			btn.Click += (sender, e) =>
			{
				this.Close();
			};

			buttons.Add(btn);
		}

		private void Btn_KeyPress(object? sender, KeyPressEventArgs e)
		{
			if (Char.IsNumber(e.KeyChar))
			{
				buttons[(int)(e.KeyChar - 49)].PerformClick();
				return;
			}
			if (Char.IsLetter(e.KeyChar))
			{
				filter += e.KeyChar;
				DrawButtons();
				return;
			}
		}

		void DrawButton(IDictionary<string, T> choicesForDraw, int rowIndex, int colIndex, IOrderedEnumerable<string> keys, int v)
		{
			var btn = new Button();
			btn.Width = 300;
			btn.Height = 300;
			btn.Left = colIndex * 300;
			btn.Top = rowIndex * 300;
			btn.Text = keys.ElementAt(v);
			btn.Tag = choicesForDraw[btn.Text];
			btn.Font = new Font(btn.Font.FontFamily, 15);
			this.Controls.Add(btn);

			btn.Click += (sender, e) =>
			{
				if (sender == null)
					return;
				var btn = (Button)sender;
				selectedKey = btn.Text;
				this.Close();
			};
			buttons.Add(btn);
			btn.KeyPress += Btn_KeyPress;
		}

		public static T Show(string title, IDictionary<string, T> choices, T defaultValue)
		{
			using (ChooesForm<T> form = new ChooesForm<T>(choices))
			{
				form.Text = title;
				form.ShowDialog();
				if (string.IsNullOrEmpty(form.selectedKey))
				{
					return defaultValue;
				}
				return form._choices[form.selectedKey];
			}

		}
	}
}
