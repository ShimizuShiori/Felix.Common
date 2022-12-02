namespace Felix.Tools.Tools
{
	[Tool("NewGuid", "C#")]
	class NewGuid : SyncTool
	{
		protected override void Start()
		{
			Clipboard.SetText(Guid.NewGuid().ToString());
		}
	}
}
