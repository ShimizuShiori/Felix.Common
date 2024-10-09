using Felix.Tools.Attributes;
using System.Text;

namespace Felix.Tools.Tools.EdiProd
{
    [TextTool("ToBranchName", "WI", regex: "(WI)\\d{8}")]
    class WINameToBranchName : ITool
    {
        public void Start()
        {
            // WI00778632 - Cannot read properties of undefined (reading 'lastIndexOf')
            var wiName = AppContext.SelectedText.Trim();
            var sb = new StringBuilder();
            var tokens = wiName.Split(new char[] { '-' });
            var wiNumber = tokens[0].Trim();
            var wiTitle = tokens[1].Trim();
            sb.Append("FLF/");
            sb.Append(wiNumber);
            sb.Append("_");

            var beginWord = true;
            foreach (var c in wiTitle)
            {
                if (char.IsWhiteSpace(c))
                {
                    beginWord = true;
                    continue;
                }
                if (!char.IsLetterOrDigit(c))
                {
                    continue;
                }
                sb.Append(beginWord ? char.ToUpper(c) : c);
                beginWord = false;
            }
            OutputBox.Show(sb.ToString());
        }
    }
}
