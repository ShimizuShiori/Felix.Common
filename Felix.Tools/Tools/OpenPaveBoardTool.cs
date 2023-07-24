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
			// https://webservices.wisetechglobal.com/Portals/PAV/Desktop#/formFlow/991905a3-0202-475e-ba39-3c18fea186b2?entityPK=1767dc3a-1671-4821-ae10-a53624fb428b
			boardNameToGuidMap["GLOW Nanjing"] = "1767dc3a-1671-4821-ae10-a53624fb428b";
		}

		public void Start()
		{
			var selectedBoardName = boardNameToGuidMap.Count == 1
				? boardNameToGuidMap.Keys.First()
				: ChooesForm<string>.Show(boardNameToGuidMap.Keys);
			if (selectedBoardName == "")
				return;

			var mode = ChooesForm<string>.Show("Browser", "Window");
			if (mode == string.Empty)
				return;

			if (mode == "Browser")
			{
				UriHelper.Open($"https://webservices.wisetechglobal.com/Portals/PAV/Desktop#/formFlow/991905a3-0202-475e-ba39-3c18fea186b2/{boardNameToGuidMap[selectedBoardName]}");
			}
			else if (mode == "Window")
			{
				UriHelper.Open($"https://svc-ediprod.wtg.zone/Services/link/ShowEditForm/VisualBoard/{boardNameToGuidMap[selectedBoardName]}?lang=en-gb");
			}
			return;
		}
	}
}
