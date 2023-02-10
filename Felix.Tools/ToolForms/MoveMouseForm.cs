using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.ToolForms
{
	[Tool("MoveMouse", "IDLE")]
	public class MoveMouseForm : Form
	{
		readonly System.Windows.Forms.Timer timer;
		readonly Random random = new Random();
		int x = 0;
		int y = 0;
		int nextX = 0;
		int nextY = 0;
		int count = 0;
		public MoveMouseForm()
		{
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 1;
			timer.Enabled = true;
			timer.Tick += Timer_Tick;
			this.Height = 1000;
			this.Width = 1000;

			this.KeyPress += MoveMouseForm_KeyPress;
			this.Shown += MoveMouseForm_Shown;
			this.StartPosition = FormStartPosition.CenterParent;
		}

		private void MoveMouseForm_Shown(object? sender, EventArgs e)
		{
			x = Cursor.Position.X;
			y = Cursor.Position.Y;
			nextX = x + random.Next(-100, 100);
			nextY = y + random.Next(-100, 100);
		}

		private void MoveMouseForm_KeyPress(object? sender, KeyPressEventArgs e)
		{
			timer.Enabled = false;
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			this.Text = $"Moving to ({nextX}, {nextY})";
			if (count++ > 100)
			{
				count = 0;
				nextX = Cursor.Position.X + random.Next(-500, 500);
				nextY = Cursor.Position.Y + random.Next(-500, 500);
			}

			User32.SetCursorPos(
				Cursor.Position.X + (int)(nextX - Cursor.Position.X) / 100,
				Cursor.Position.Y + (int)(nextY - Cursor.Position.Y) / 100);
		}
	}
}
