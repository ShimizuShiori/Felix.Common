using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Felix.Common
{
	public class User32
	{

		public const uint WM_GETTEXTLENGTH = 0x000E;
		public const uint WM_GETTEXT = 0x000D;
		public const int WM_KEYDOWN = 0x0100;
		public const int WM_KEYUP = 0x0101;
		public const int WM_CHAR = 0x102;
		public const int WM_SYSKEYDOWN = 0x0104;
		public const int WM_SYSKEYUP = 0x0105;
		public const uint EM_GETSEL = 0xB0;
		public const int WM_SETFOCUS = 0x0007;

		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		[DllImport("User32.Dll")]
		public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int x;
			public int y;

			public POINT(int X, int Y)
			{
				x = X;
				y = Y;
			}
		}

		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern int SetWindowPos(
		  int hwnd, //用于设置的窗体的句柄
		  int hWndInsertAfter,//用于对窗体最前端的操作（查手册获取相应的参数常量）
		  int x,//窗体的坐标x
		  int y,//窗体的坐标y
		  int cx,//窗体的长
		  int cy,//窗体的宽
		  int wFlags //对窗体的操作（查手册获取相应的参数常量）
		);

		[DllImport("user32.dll", EntryPoint = "GetWindowText")]
		public static extern int GetWindowText(
			int hwnd,//句柄
			StringBuilder lpString,
			int cch
		);

		[DllImport("user32.dll", EntryPoint = "WindowFromPoint")]//获取当前点下的窗体或控件的句柄
		public static extern int WindowFromPoint(
			int xPoint,
			int yPoint
		);

		[DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]//获取当前句柄中的文字长度
		public static extern int GetWindowTextLength(
			int hwnd
		);


		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wparam, IntPtr lparam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern int SendMessage(IntPtr hWnd, uint Msg, out int wParam, out int lParam);

		[DllImport("user32.dll", EntryPoint = "SendMessageA")]
		public static extern int SendMessageA(
		   IntPtr hWnd,
		   int Msg,
		   uint wParam,
		   uint lParam
		); 
		
		[DllImport("user32.dll", EntryPoint = "SendMessage")]
		public static extern int SendMessage(
			IntPtr hWnd,
			int Msg,
			uint wParam,
			uint lParam
		);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern IntPtr GetFocus();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowThreadProcessId(int handle, out int processId);

		[DllImport("user32", SetLastError = true, ExactSpelling = true)]
		public static extern int AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);

		[DllImport("kernel32.dll")]
		public static extern int GetCurrentThreadId();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr hwnd, int id, KeyModifiers fsModifiers, Keys vk);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnregisterHotKey(
			IntPtr hWnd,                //要取消热键的窗口的句柄
			int id                      //要取消热键的ID
		);

		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", EntryPoint = "FindWindowEx")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll")]
		public static extern bool SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		
		[DllImport("user32", SetLastError = true)]
		public static extern bool PostMessage(
			int hWnd,
			uint Msg,
			int wParam,
			int lParam
		); 
	
		[DllImport("user32.dll", EntryPoint = "keybd_event")]
		public static extern void keybd_event(
		  byte bVk,    //虚拟键值
		  byte bScan,// 一般为0
		  int dwFlags,  //这里是整数类型  0 为按下，2为释放
		  int dwExtraInfo  //这里是整数类型 一般情况下设成为 0
	  );
	}
	
}
