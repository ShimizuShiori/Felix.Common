using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.ToolForms
{
	[Tool("IdleWI", "EdiProd")]
	public class MyIdleForm : Form
	{
		const string url = "edient:Command=ShowEditForm&ControllerID=WorkItem&BusinessEntityPK=053dcd6a-21dc-459a-9323-4f8fa8871add&Domain=wtg.zone&Instance=ediProd&Hash=%2bnKuhLSFVZKwnE7sFrMa8oHM2rcmrlO9W";
		public MyIdleForm()
		{
			this.Shown += EdiProdForm_Shown;
		}

		private void EdiProdForm_Shown(object? sender, EventArgs e)
		{
			UrlHelper.Open(url);
			this.Close();
		}
	}
}
