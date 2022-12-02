namespace Felix.Tools.ToolForms
{
	[Tool("Xml Converter", "Xml")]
	public partial class XmlConvertForm : Form
	{
		string rawXml = "";
		string parsedXml = "";

		public event EventHandler RawXmlUpdated;
		public event EventHandler ParsedXmlUpdated;

		public XmlConvertForm()
		{
			InitializeComponent();
			this.RawXmlUpdated += XmlConvertForm_RawXmlUpdated;
			this.ParsedXmlUpdated += XmlConvertForm_ParsedXmlUpdated;
		}

		private void XmlConvertForm_ParsedXmlUpdated(object? sender, EventArgs e)
		{
			RawXml = ParseParsedXml(parsedXml);

			if (parsedXml == txtParsedXml.Text)
				return;

			txtParsedXml.Text = parsedXml;
		}

		private void XmlConvertForm_RawXmlUpdated(object? sender, EventArgs e)
		{
			ParsedXml = ParseRawXml(rawXml);

			if (rawXml == txtRawXml.Text)
				return;

			txtRawXml.Text = rawXml;
		}

		public string RawXml
		{
			get => rawXml;
			set
			{
				if (value == rawXml)
				{
					return;
				}
				rawXml = value;
				RawXmlUpdated?.Invoke(this, EventArgs.Empty);
			}
		}

		public string ParsedXml
		{
			get => parsedXml;
			set
			{
				if (value == parsedXml)
				{
					return;
				}
				parsedXml = value;
				ParsedXmlUpdated?.Invoke(this, EventArgs.Empty);
			}
		}

		private void txtRawXml_TextChanged(object sender, EventArgs e)
		{
			this.RawXml = txtRawXml.Text;
		}

		private void txtParsedXml_TextChanged(object sender, EventArgs e)
		{
			if (this.ParsedXml == txtParsedXml.Text)
				return;
			this.ParsedXml = txtParsedXml.Text;
		}

		string ParseRawXml(string rawString)
		{
			return rawString.Replace("<", "&lt;").Replace(">", "&gt;");
		}

		string ParseParsedXml(string parsedXml)
		{
			return parsedXml.Replace("&lt;", "<").Replace("&gt;", ">");
		}
	}
}
