namespace Felix.Tools
{
	interface ICopiedInfo
	{
	}

	class TextCopiedInfo : ICopiedInfo
	{
		public string Text { get; }

		public TextCopiedInfo(string text)
		{
			Text = text;
		}
	}

	class FilePathListCopiedInfo : ICopiedInfo
	{
		public string[] FilePathList { get; }

		public FilePathListCopiedInfo(string[] filePathList)
		{
			FilePathList = filePathList;
		}

		public FilePathListCopiedInfo(IEnumerable<string> filePathList)
			: this(filePathList.ToArray())
		{

		}
	}

	class NullCopiedInfo : ICopiedInfo
	{
		NullCopiedInfo()
		{
		}

		static readonly ICopiedInfo instance = new NullCopiedInfo();

		public static ICopiedInfo Instance { get => instance; }
	}

	static class CopiedInfoExt
	{
		public static bool IsNull(this ICopiedInfo copiedInfo)
		{
			return copiedInfo is NullCopiedInfo;
		}
	}

	static class CopiedInfoFactory
	{
		public static ICopiedInfo Create()
		{
			try
			{
				if (Clipboard.ContainsText())
				{
					return new TextCopiedInfo(Clipboard.GetText().Trim());
				}

				if (Clipboard.ContainsFileDropList())
				{
					return new FilePathListCopiedInfo(Clipboard.GetFileDropList().Cast<string>());
				}

				return NullCopiedInfo.Instance;
			}
			catch (Exception)
			{
				return NullCopiedInfo.Instance;
			}
		}
	}
}
