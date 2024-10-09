using Felix.Tools.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Tools.Tools
{
    [TextTool("OrderText", "Text", regex: @"\n")]
    class OrderStrings : ITool
    {
        public void Start()
        {
            var lines = AppContext.SelectedText.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).OrderBy(l => l).ToList();
            OutputBox.Show(string.Join('\n', lines));
        }
    }
}
