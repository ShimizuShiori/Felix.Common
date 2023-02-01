namespace Felix.Tools.Tools
{
	class NullTool : ITool
	{
		NullTool()
		{

		}
		public Task StartAsync()
		{
			return Task.CompletedTask;
		}

		static readonly ITool nullTool = new NullTool();

		public static ITool Default
		{
			get => nullTool;
		}
	}
}
