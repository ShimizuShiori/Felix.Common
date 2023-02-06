using Felix.Tools.Forms;
using Felix.Tools.ToolFactories;

namespace Felix.Tools
{
	static class AppContext
	{
		static Queue<object> uiMessageQueue = new Queue<object>();
		static List<IUiMessageListener> listeners = new List<IUiMessageListener>();
		static object uiQueueLock = new object();

		public static ICopiedInfo CopiedInfo { get; set; } = NullCopiedInfo.Instance;
		public static string SelectedCategory { get; set; } = string.Empty;
		public static IToolFactory ToolFactory { get; } = new ToolFactory();
		public static JobCounter JobCounter { get; } = new JobCounter();
		public static Random Random { get; } = new Random();
		public static string SelectedText
		{
			get
			{
				if (CopiedInfo is TextCopiedInfo t)
				{
					return t.Text;
				}
				else if (CopiedInfo is FilePathListCopiedInfo f)
				{
					return f.FilePathList[0];
				}
				return string.Empty;
			}
		}
		public static string[] SelectedFilePathList
		{
			get
			{
				if (CopiedInfo is FilePathListCopiedInfo f)
				{
					return f.FilePathList;
				}
				return Array.Empty<string>();
			}
		}

		static AppContext()
		{
			InitUiMessageHandler();
		}

		private static void InitUiMessageHandler()
		{
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Enabled = true;
			timer.Tick += Timer_Tick;
		}

		private static void Timer_Tick(object? sender, EventArgs e)
		{
			if (sender == null)
				return;
			System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
			timer.Enabled = false;
			Queue<object> queue = new Queue<object>();

			lock (uiQueueLock)
				while (uiMessageQueue.Count > 0)
					queue.Enqueue(uiMessageQueue.Dequeue());

			while (queue.Count > 0)
			{
				object message = queue.Dequeue();
				foreach (var listener in listeners)
					listener.OnMessage(message);
			}
			timer.Enabled = true;
		}

		public static void PublishUiMessage(object message)
		{
			lock (uiMessageQueue)
				uiMessageQueue.Enqueue(message);
		}

		public static IDisposable RegisterUiMessageListener(IUiMessageListener uiMessageListener)
		{
			listeners.Add(uiMessageListener);
			return new ActionDisposable(() => listeners.Remove(uiMessageListener));
		}
	}
}
