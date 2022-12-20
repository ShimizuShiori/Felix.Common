﻿using System.Diagnostics;

namespace Felix.Tools.Tools
{
	[Tool("Close", "Local CW1")]
	class CloseCW1 : ITool
	{
		public Task StartAsync()
		{
			return Task.Run(() =>
			{
				while (true)
				{
					var ps = Process.GetProcessesByName("CargoWiseOneAnyCpu");
					if (ps.Length == 0) break;
					try
					{
						foreach (var p in ps)
							p.CloseMainWindow();
					}
					finally
					{
						foreach (var p in ps)
							p.Dispose();
					}
				}
			});
		}
	}
}
