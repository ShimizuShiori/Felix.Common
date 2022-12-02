namespace Felix.Tools.Tools
{
	class NullTool : ITool
	{
		NullTool()
		{

		}
		public void Start()
		{
		}

		static readonly ITool nullTool = new NullTool();

		public static ITool Default
		{
			get => nullTool;
		}
	}
}
