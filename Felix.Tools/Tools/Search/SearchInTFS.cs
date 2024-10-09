using Felix.Common;
using Felix.Tools.Attributes;
using Felix.Tools.SharedInfos;

namespace Felix.Tools.Tools.Search
{
    [TextTool("TFS", "Search")]
    class SearchInTFS : ITool
    {
        public void Start()
        {
            var mode = new (string, string)[]
            {
                ("All", "\"{0}\""),
                ("BaseType", "basetype: {0}"),
                ("Ref", "ref: {0}"),
                ("Def", "def: {0}"),
                ("Str", "strlit: {0}")
            };

            var selectedFormat = ChooesForm<string>.Show(
                "select mode",
                mode.ToMap(x => (x.Item1, x.Item2)),
                "");
            if (selectedFormat == string.Empty)
                return;

            //var selectedRepo = ChooesForm<string>.Show(
            //    TFSInfos.GetProjects().Concat(new string[]
            //    {
            //        "All"
            //    }));
            //if (selectedRepo == string.Empty)
            //    return;

            var sText = UriHelper.Encode(string.Format(selectedFormat, AppContext.SelectedText));
            //if (selectedRepo == "All")
            //{
            UriHelper.Open($"https://devops.wisetechglobal.com/wtg/_search?text={sText}&type=code");
            //}
            //else
            //{
            //    UriHelper.Open($"https://devops.wisetechglobal.com/wtg/{selectedRepo}/_search?text={sText}&type=code");
            //}
        }
    }
}
