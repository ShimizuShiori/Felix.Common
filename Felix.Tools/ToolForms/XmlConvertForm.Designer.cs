namespace Felix.Tools.ToolForms
{
	partial class XmlConvertForm
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtRawXml = new System.Windows.Forms.TextBox();
			this.txtParsedXml = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtRawXml);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtParsedXml);
			this.splitContainer1.Size = new System.Drawing.Size(1968, 912);
			this.splitContainer1.SplitterDistance = 1000;
			this.splitContainer1.TabIndex = 0;
			// 
			// txtRawXml
			// 
			this.txtRawXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtRawXml.Location = new System.Drawing.Point(0, 0);
			this.txtRawXml.Multiline = true;
			this.txtRawXml.Name = "txtRawXml";
			this.txtRawXml.Size = new System.Drawing.Size(1000, 912);
			this.txtRawXml.TabIndex = 1;
			this.txtRawXml.TextChanged += new System.EventHandler(this.txtRawXml_TextChanged);
			// 
			// txtParsedXml
			// 
			this.txtParsedXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtParsedXml.Location = new System.Drawing.Point(0, 0);
			this.txtParsedXml.Multiline = true;
			this.txtParsedXml.Name = "txtParsedXml";
			this.txtParsedXml.Size = new System.Drawing.Size(964, 912);
			this.txtParsedXml.TabIndex = 2;
			this.txtParsedXml.TextChanged += new System.EventHandler(this.txtParsedXml_TextChanged);
			// 
			// XmlConvertForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1968, 912);
			this.Controls.Add(this.splitContainer1);
			this.Name = "XmlConvertForm";
			this.Text = "XmlConvertForm";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private SplitContainer splitContainer1;
		private TextBox txtRawXml;
		private TextBox txtParsedXml;
	}
}