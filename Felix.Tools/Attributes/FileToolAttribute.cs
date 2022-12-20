namespace Felix.Tools.Attributes
{
	class FileToolAttribute : ToolAttribute
	{
		public FileToolAttribute(string name, string category) : base(name, category)
		{
		}

		public override bool Show()
		{
			return base.Show()
				&& AppContext.CopiedInfo is FilePathListCopiedInfo;
		}
	}
}
