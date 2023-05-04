namespace Felix.Common
{
	public class ArgsReader
	{
		readonly string[] args;
		int index = 0;

		int ArgsLength { get => args.Length; }

		public ArgsReader(string[] args)
		{
			this.args = args;
		}

		public bool TryRead(out string arg)
		{
			if (index < ArgsLength)
			{
				arg = args[index++];
				return true;
			}
			arg = string.Empty;
			return false;
		}

		public ArgsReader Clone()
		{
			return new ArgsReader(args)
			{
				index = index
			};
		}
	}

	public static class ArgsReaderExtension
	{
		public static string Read(this ArgsReader reader, string defaultArgument)
		{
			if (reader.TryRead(out var arg))
				return arg;

			return defaultArgument;
		}
		public static string Read(this ArgsReader reader, Func<string> defaultArgumentFactory)
		{
			if (reader.TryRead(out var arg))
				return arg;

			return defaultArgumentFactory();
		}

		public static int ReadInt(this ArgsReader reader, int defaultArgument)
		{
			var arg = reader.Read(() => defaultArgument.ToString());
			return Convert.ToInt32(arg);
		}
	}
}
