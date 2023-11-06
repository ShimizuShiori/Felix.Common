namespace Felix.Tools
{
	partial class GitHelperForm
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.BranchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BranchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.BranchToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fetchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.addAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.raseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.revertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
			this.textBox1.Location = new System.Drawing.Point(0, 58);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(1968, 1854);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = ">> ";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BranchMenuItem,
            this.remoteToolStripMenuItem,
            this.statuToolStripMenuItem,
            this.stageToolStripMenuItem,
            this.consoleToolStripMenuItem});
			this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.menuStrip1.Size = new System.Drawing.Size(1968, 58);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// BranchMenuItem
			// 
			this.BranchMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BranchListMenuItem,
            this.BranchToMenuItem,
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.BranchMenuItem.Name = "BranchMenuItem";
			this.BranchMenuItem.Size = new System.Drawing.Size(158, 54);
			this.BranchMenuItem.Text = "&Branch";
			// 
			// BranchListMenuItem
			// 
			this.BranchListMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localToolStripMenuItem,
            this.remoteToolStripMenuItem1});
			this.BranchListMenuItem.Name = "BranchListMenuItem";
			this.BranchListMenuItem.Size = new System.Drawing.Size(297, 58);
			this.BranchListMenuItem.Text = "&List";
			// 
			// localToolStripMenuItem
			// 
			this.localToolStripMenuItem.Name = "localToolStripMenuItem";
			this.localToolStripMenuItem.Size = new System.Drawing.Size(318, 58);
			this.localToolStripMenuItem.Text = "&Local";
			this.localToolStripMenuItem.Click += new System.EventHandler(this.localToolStripMenuItem_Click);
			// 
			// remoteToolStripMenuItem1
			// 
			this.remoteToolStripMenuItem1.Name = "remoteToolStripMenuItem1";
			this.remoteToolStripMenuItem1.Size = new System.Drawing.Size(318, 58);
			this.remoteToolStripMenuItem1.Text = "&Remote";
			this.remoteToolStripMenuItem1.Click += new System.EventHandler(this.remoteToolStripMenuItem1_Click);
			// 
			// BranchToMenuItem
			// 
			this.BranchToMenuItem.Name = "BranchToMenuItem";
			this.BranchToMenuItem.Size = new System.Drawing.Size(297, 58);
			this.BranchToMenuItem.Text = "&To";
			this.BranchToMenuItem.Click += new System.EventHandler(this.BranchToMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(297, 58);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(297, 58);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// remoteToolStripMenuItem
			// 
			this.remoteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pushToolStripMenuItem,
            this.pullToolStripMenuItem,
            this.fetchToolStripMenuItem});
			this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
			this.remoteToolStripMenuItem.Size = new System.Drawing.Size(172, 54);
			this.remoteToolStripMenuItem.Text = "&Remote";
			// 
			// pushToolStripMenuItem
			// 
			this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
			this.pushToolStripMenuItem.Size = new System.Drawing.Size(280, 58);
			this.pushToolStripMenuItem.Text = "Pu&sh";
			this.pushToolStripMenuItem.Click += new System.EventHandler(this.pushToolStripMenuItem_Click);
			// 
			// pullToolStripMenuItem
			// 
			this.pullToolStripMenuItem.Name = "pullToolStripMenuItem";
			this.pullToolStripMenuItem.Size = new System.Drawing.Size(280, 58);
			this.pullToolStripMenuItem.Text = "Pu&ll";
			this.pullToolStripMenuItem.Click += new System.EventHandler(this.pullToolStripMenuItem_Click);
			// 
			// fetchToolStripMenuItem
			// 
			this.fetchToolStripMenuItem.Name = "fetchToolStripMenuItem";
			this.fetchToolStripMenuItem.Size = new System.Drawing.Size(280, 58);
			this.fetchToolStripMenuItem.Text = "&Fetch";
			this.fetchToolStripMenuItem.Click += new System.EventHandler(this.fetchToolStripMenuItem_Click);
			// 
			// statuToolStripMenuItem
			// 
			this.statuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripMenuItem,
            this.toolStripSeparator2,
            this.addAllToolStripMenuItem,
            this.commitToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.raseToolStripMenuItem,
            this.cleanToolStripMenuItem,
            this.toolStripSeparator1,
            this.logsToolStripMenuItem});
			this.statuToolStripMenuItem.Name = "statuToolStripMenuItem";
			this.statuToolStripMenuItem.Size = new System.Drawing.Size(147, 54);
			this.statuToolStripMenuItem.Text = "&Status";
			// 
			// statusToolStripMenuItem
			// 
			this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
			this.statusToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.statusToolStripMenuItem.Text = "&Status";
			this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(320, 6);
			// 
			// addAllToolStripMenuItem
			// 
			this.addAllToolStripMenuItem.Name = "addAllToolStripMenuItem";
			this.addAllToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.addAllToolStripMenuItem.Text = "&Add";
			this.addAllToolStripMenuItem.Click += new System.EventHandler(this.addAllToolStripMenuItem_Click);
			// 
			// commitToolStripMenuItem
			// 
			this.commitToolStripMenuItem.Name = "commitToolStripMenuItem";
			this.commitToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.commitToolStripMenuItem.Text = "&Commit";
			this.commitToolStripMenuItem.Click += new System.EventHandler(this.commitToolStripMenuItem_Click);
			// 
			// mergeToolStripMenuItem
			// 
			this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
			this.mergeToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.mergeToolStripMenuItem.Text = "&Merge";
			this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
			// 
			// raseToolStripMenuItem
			// 
			this.raseToolStripMenuItem.Name = "raseToolStripMenuItem";
			this.raseToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.raseToolStripMenuItem.Text = "&Rebase";
			this.raseToolStripMenuItem.Click += new System.EventHandler(this.raseToolStripMenuItem_Click);
			// 
			// cleanToolStripMenuItem
			// 
			this.cleanToolStripMenuItem.Name = "cleanToolStripMenuItem";
			this.cleanToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.cleanToolStripMenuItem.Text = "C&lean";
			this.cleanToolStripMenuItem.Click += new System.EventHandler(this.cleanToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(320, 6);
			// 
			// logsToolStripMenuItem
			// 
			this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
			this.logsToolStripMenuItem.Size = new System.Drawing.Size(323, 58);
			this.logsToolStripMenuItem.Text = "&Logs";
			this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
			// 
			// stageToolStripMenuItem
			// 
			this.stageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.revertToolStripMenuItem});
			this.stageToolStripMenuItem.Name = "stageToolStripMenuItem";
			this.stageToolStripMenuItem.Size = new System.Drawing.Size(138, 54);
			this.stageToolStripMenuItem.Text = "S&tage";
			// 
			// restoreToolStripMenuItem
			// 
			this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
			this.restoreToolStripMenuItem.Size = new System.Drawing.Size(315, 58);
			this.restoreToolStripMenuItem.Text = "Re&store";
			this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
			// 
			// revertToolStripMenuItem
			// 
			this.revertToolStripMenuItem.Name = "revertToolStripMenuItem";
			this.revertToolStripMenuItem.Size = new System.Drawing.Size(315, 58);
			this.revertToolStripMenuItem.Text = "Re&vert";
			this.revertToolStripMenuItem.Click += new System.EventHandler(this.revertToolStripMenuItem_Click);
			// 
			// consoleToolStripMenuItem
			// 
			this.consoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
			this.consoleToolStripMenuItem.Size = new System.Drawing.Size(178, 54);
			this.consoleToolStripMenuItem.Text = "&Console";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(275, 58);
			this.clearToolStripMenuItem.Text = "&Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// GitHelperForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1968, 1912);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "GitHelperForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Git Helper";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private TextBox textBox1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem BranchMenuItem;
		private ToolStripMenuItem BranchListMenuItem;
		private ToolStripMenuItem BranchToMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem statuToolStripMenuItem;
		private ToolStripMenuItem consoleToolStripMenuItem;
		private ToolStripMenuItem clearToolStripMenuItem;
		private ToolStripMenuItem remoteToolStripMenuItem;
		private ToolStripMenuItem pushToolStripMenuItem;
		private ToolStripMenuItem pullToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem statusToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem logsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem addAllToolStripMenuItem;
		private ToolStripMenuItem commitToolStripMenuItem;
		private ToolStripMenuItem mergeToolStripMenuItem;
		private ToolStripMenuItem raseToolStripMenuItem;
		private ToolStripMenuItem cleanToolStripMenuItem;
		private ToolStripMenuItem stageToolStripMenuItem;
		private ToolStripMenuItem restoreToolStripMenuItem;
		private ToolStripMenuItem revertToolStripMenuItem;
		private ToolStripMenuItem localToolStripMenuItem;
		private ToolStripMenuItem remoteToolStripMenuItem1;
		private ToolStripMenuItem fetchToolStripMenuItem;
	}
}