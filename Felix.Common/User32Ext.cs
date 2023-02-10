using System.Text;

namespace Felix.Common
{
	public class User32Ext : User32
	{
		public static string GetSelectedText()
		{
			//获取活动窗口的控件hWnd
			int activeWinPtr = GetForegroundWindow().ToInt32();
			int activeThreadId = 0;
			int processId;
			activeThreadId = GetWindowThreadProcessId(activeWinPtr, out processId);
			int currentThreadId = GetCurrentThreadId();
			if (activeThreadId != currentThreadId)
				AttachThreadInput(activeThreadId, currentThreadId, true);
			IntPtr activeCtrlId = GetFocus();

			//获取全部文本长度
			int textlength = (int)SendMessage(activeCtrlId, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero) + 1;

			//Have any text at all?
			if (textlength > 0)
			{
				//Get selection
				int selstart;
				int selend;
				SendMessage(activeCtrlId, EM_GETSEL, out selstart, out selend);

				StringBuilder sb = new StringBuilder(textlength);
				SendMessage(activeCtrlId, WM_GETTEXT, (IntPtr)textlength, sb);

				//Slice out selection
				string value = sb.ToString();
				sb.Clear();
				//if ((value.Length > 0) && (selend - selstart > 0) && (selstart < value.Length) && (selend < value.Length))
				return value.Substring(selstart, selend - selstart);
			}

			//失败返回null
			return null;
		}
	}
}
