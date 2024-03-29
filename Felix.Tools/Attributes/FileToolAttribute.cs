﻿namespace Felix.Tools.Attributes
{
	class FileToolAttribute : ToolAttribute
	{
		readonly string ext;
		public FileToolAttribute(string name, string category, string ext = "") : base(name, category)
		{
			this.ext = ext;
		}

		public override bool Show()
		{
			return base.Show()
				&& AppContext.CopiedInfo is FilePathListCopiedInfo f
				&& (ext == "" || f.FilePathList.Any(x => Path.GetExtension(x) == $".{ext}"));
		}
	}
}
