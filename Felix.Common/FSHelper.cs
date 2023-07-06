namespace Felix.Common
{
	public static class FSHelper
	{
		public static Stream? CreateFile(string file)
		{
			var info = new FileInfo(file);
			if (info.Exists)
				return null;

			if (info.Directory == null)
				return null;

			if (!info.Directory.Exists)
				info.Directory.Create();

			return info.Create();

		}
	}
}
