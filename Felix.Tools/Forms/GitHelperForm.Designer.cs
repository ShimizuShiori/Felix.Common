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
			this.BranchToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.addAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.commitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.raseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
			this.textBox1.Location = new System.Drawing.Point(0, 49);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(1968, 1863);
			this.textBox1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BranchMenuItem,
            this.remoteToolStripMenuItem,
            this.statuToolStripMenuItem,
            this.consoleToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1968, 49);
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
			this.BranchMenuItem.Size = new System.Drawing.Size(150, 48);
			this.BranchMenuItem.Text = "(&B)ranch";
			// 
			// BranchListMenuItem
			// 
			this.BranchListMenuItem.Name = "BranchListMenuItem";
			this.BranchListMenuItem.Size = new System.Drawing.Size(288, 54);
			this.BranchListMenuItem.Text = "(&L)ist";
			this.BranchListMenuItem.Click += new System.EventHandler(this.BranchListMenuItem_Click);
			// 
			// BranchToMenuItem
			// 
			this.BranchToMenuItem.Name = "BranchToMenuItem";
			this.BranchToMenuItem.Size = new System.Drawing.Size(288, 54);
			this.BranchToMenuItem.Text = "(&T)o";
			this.BranchToMenuItem.Click += new System.EventHandler(this.BranchToMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(288, 54);
			this.newToolStripMenuItem.Text = "(&N)ew";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(288, 54);
			this.deleteToolStripMenuItem.Text = "(&D)elete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// remoteToolStripMenuItem
			// 
			this.remoteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pushToolStripMenuItem,
            this.pullToolStripMenuItem});
			this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
			this.remoteToolStripMenuItem.Size = new System.Drawing.Size(164, 48);
			this.remoteToolStripMenuItem.Text = "(&R)emote";
			// 
			// pushToolStripMenuItem
			// 
			this.pushToolStripMenuItem.Name = "pushToolStripMenuItem";
			this.pushToolStripMenuItem.Size = new System.Drawing.Size(266, 54);
			this.pushToolStripMenuItem.Text = "Pu(&s)h";
			this.pushToolStripMenuItem.Click += new System.EventHandler(this.pushToolStripMenuItem_Click);
			// 
			// pullToolStripMenuItem
			// 
			this.pullToolStripMenuItem.Name = "pullToolStripMenuItem";
			this.pullToolStripMenuItem.Size = new System.Drawing.Size(266, 54);
			this.pullToolStripMenuItem.Text = "Pu(&l)l";
			this.pullToolStripMenuItem.Click += new System.EventHandler(this.pullToolStripMenuItem_Click);
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
            this.toolStripSeparator1,
            this.logsToolStripMenuItem});
			this.statuToolStripMenuItem.Name = "statuToolStripMenuItem";
			this.statuToolStripMenuItem.Size = new System.Drawing.Size(141, 48);
			this.statuToolStripMenuItem.Text = "(&S)tatus";
			// 
			// statusToolStripMenuItem
			// 
			this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
			this.statusToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.statusToolStripMenuItem.Text = "(&S)tatus";
			this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(445, 6);
			// 
			// addAllToolStripMenuItem
			// 
			this.addAllToolStripMenuItem.Name = "addAllToolStripMenuItem";
			this.addAllToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.addAllToolStripMenuItem.Text = "(&A)dd All";
			this.addAllToolStripMenuItem.Click += new System.EventHandler(this.addAllToolStripMenuItem_Click);
			// 
			// commitToolStripMenuItem
			// 
			this.commitToolStripMenuItem.Name = "commitToolStripMenuItem";
			this.commitToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.commitToolStripMenuItem.Text = "(&C)ommit";
			this.commitToolStripMenuItem.Click += new System.EventHandler(this.commitToolStripMenuItem_Click);
			// 
			// mergeToolStripMenuItem
			// 
			this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
			this.mergeToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.mergeToolStripMenuItem.Text = "(&M)erge";
			this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
			// 
			// raseToolStripMenuItem
			// 
			this.raseToolStripMenuItem.Name = "raseToolStripMenuItem";
			this.raseToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.raseToolStripMenuItem.Text = "(&R)ase";
			this.raseToolStripMenuItem.Click += new System.EventHandler(this.raseToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(445, 6);
			// 
			// logsToolStripMenuItem
			// 
			this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
			this.logsToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
			this.logsToolStripMenuItem.Text = "(&L)ogs";
			this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
			// 
			// consoleToolStripMenuItem
			// 
			this.consoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
			this.consoleToolStripMenuItem.Size = new System.Drawing.Size(168, 48);
			this.consoleToolStripMenuItem.Text = "(&C)onsole";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(269, 54);
			this.clearToolStripMenuItem.Text = "(&C)lear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 1858);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1968, 54);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(297, 41);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// GitHelperForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1968, 1912);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "GitHelperForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Git Helper";
			this.Load += new System.EventHandler(this.TestForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
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
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem statusToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem logsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem addAllToolStripMenuItem;
		private ToolStripMenuItem commitToolStripMenuItem;
		private ToolStripMenuItem mergeToolStripMenuItem;
		private ToolStripMenuItem raseToolStripMenuItem;
	}
}