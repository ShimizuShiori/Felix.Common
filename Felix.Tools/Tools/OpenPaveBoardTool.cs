using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools
{
	[Tool("Pave", "EdiProd")]
	class OpenPaveBoardTool : ITool
	{
		static readonly IDictionary<string, string> boardNameToGuidMap = new Dictionary<string, string>();

		static OpenPaveBoardTool()
		{
			boardNameToGuidMap["GLOW"] = "f07ab6cf-183d-43ac-984d-7b9b1f47cb47";
		}

		public Task StartAsync()
		{
			var selectedBoardName = boardNameToGuidMap.Count == 1
				? boardNameToGuidMap.Keys.First()
				: ChooesForm<string>.Show(boardNameToGuidMap.Keys);
			if (selectedBoardName == "")
				return Task.CompletedTask;

			var mode = ChooesForm<string>.Show("Browser", "Window");
			if (mode == String.Empty)
				return Task.CompletedTask;

			if (mode == "Browser")
			{
				UrlHelper.Open($"https://webservices.wisetechglobal.com/Portals/PAV/Desktop#/formFlow/a2a6c1cf-cf54-4793-91ac-790314109fec/{boardNameToGuidMap[selectedBoardName]}");
			}
			else if (mode == "Window")
			{
				UrlHelper.Open($"https://svc-ediprod.wtg.zone/Services/link/ShowEditForm/VisualBoard/{boardNameToGuidMap[selectedBoardName]}?lang=en-gb");
			}
			return Task.CompletedTask;
		}
	}
}
