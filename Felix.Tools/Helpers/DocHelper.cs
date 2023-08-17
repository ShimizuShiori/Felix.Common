using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Tools.Helpers
{
	static class DocHelper
	{


		const string DocPath = @"C:\Users\Felix.Fei\Documents\Docs\Glow";

		public static IEnumerable<DocInfo> GetAllWorkItems(WorkItemStates state)
		{
			string path = Path.Combine(DocPath, state.ToString());
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
				return Enumerable.Empty<DocInfo>();
			}

			return directoryInfo.GetDirectories()
				.Select(x => new DocInfo(x.FullName, x.Name, state));
		}

		public static DocInfo Finish(DocInfo info)
		{
			if (info.State == WorkItemStates.FIN)
				return info;

			string newPath = Path.Combine(DocPath, WorkItemStates.FIN.ToString(), info.Name);
			Directory.Move(info.FullPath, newPath);
			return new DocInfo(newPath, info.Name, WorkItemStates.FIN);
		}

		public static DocInfo Create(string workItem)
		{
			string path = Path.Combine(DocPath, WorkItemStates.WRK.ToString(), workItem);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return new DocInfo(path, workItem, WorkItemStates.WRK);
		}

		public enum WorkItemStates
		{
			FIN,
			WRK
		}

		public record DocInfo(string FullPath, string Name, WorkItemStates State);
	}
}
