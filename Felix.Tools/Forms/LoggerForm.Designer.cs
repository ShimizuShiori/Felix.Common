namespace Felix.Tools.Forms
{
	partial class LoggerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.RootMenuStrip = new System.Windows.Forms.MenuStrip();
			this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.RootMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootMenuStrip
			// 
			this.RootMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.RootMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.EditMenuItem,
            this.ActionMenuItem});
			this.RootMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.RootMenuStrip.Name = "RootMenuStrip";
			this.RootMenuStrip.Size = new System.Drawing.Size(1968, 49);
			this.RootMenuStrip.TabIndex = 0;
			this.RootMenuStrip.Text = "RuntimeLogs";
			// 
			// FileMenuItem
			// 
			this.FileMenuItem.Name = "FileMenuItem";
			this.FileMenuItem.Size = new System.Drawing.Size(87, 45);
			this.FileMenuItem.Text = "File";
			// 
			// EditMenuItem
			// 
			this.EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearMenuItem});
			this.EditMenuItem.Name = "EditMenuItem";
			this.EditMenuItem.Size = new System.Drawing.Size(92, 45);
			this.EditMenuItem.Text = "Edit";
			// 
			// ClearMenuItem
			// 
			this.ClearMenuItem.Name = "ClearMenuItem";
			this.ClearMenuItem.Size = new System.Drawing.Size(251, 54);
			this.ClearMenuItem.Text = "Clear";
			this.ClearMenuItem.Click += new System.EventHandler(this.ClearMenuItem_Click);
			// 
			// ActionMenuItem
			// 
			this.ActionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartMenuItem,
            this.StopMenuItem});
			this.ActionMenuItem.Name = "ActionMenuItem";
			this.ActionMenuItem.Size = new System.Drawing.Size(140, 45);
			this.ActionMenuItem.Text = "Actions";
			// 
			// StartMenuItem
			// 
			this.StartMenuItem.Name = "StartMenuItem";
			this.StartMenuItem.Size = new System.Drawing.Size(448, 54);
			this.StartMenuItem.Text = "Start";
			this.StartMenuItem.Click += new System.EventHandler(this.StartMenuItem_Click);
			// 
			// StopMenuItem
			// 
			this.StopMenuItem.Name = "StopMenuItem";
			this.StopMenuItem.Size = new System.Drawing.Size(448, 54);
			this.StopMenuItem.Text = "Stop";
			this.StopMenuItem.Click += new System.EventHandler(this.StopMenuItem_Click);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 49);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(1968, 1863);
			this.textBox1.TabIndex = 1;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// LoggerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1968, 1912);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.RootMenuStrip);
			this.MainMenuStrip = this.RootMenuStrip;
			this.Name = "LoggerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Runtime Logs";
			this.RootMenuStrip.ResumeLayout(false);
			this.RootMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MenuStrip RootMenuStrip;
		private ToolStripMenuItem FileMenuItem;
		private ToolStripMenuItem EditMenuItem;
		private ToolStripMenuItem ClearMenuItem;
		private TextBox textBox1;
		private System.Windows.Forms.Timer timer1;
		private ToolStripMenuItem ActionMenuItem;
		private ToolStripMenuItem StartMenuItem;
		private ToolStripMenuItem StopMenuItem;
	}
}