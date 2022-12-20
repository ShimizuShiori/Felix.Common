using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[Tool("NewGuid", "C#")]
	class NewGuid : SyncTool
	{
		protected override void Start()
		{
			//Clipboard.SetText(Guid.NewGuid().ToString());
			OutputBox.Show(Guid.NewGuid().ToString());
		}
	}
}
