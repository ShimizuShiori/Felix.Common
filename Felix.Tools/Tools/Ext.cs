namespace Felix.Tools.Tools
{
	static class Ext
	{
		public static bool IsNull(this ITool tool)
		{
			return tool == NullTool.Default;
		}
	}
}
