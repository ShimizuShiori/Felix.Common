using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace ConsoleExTest
{
	internal class SocketDemos
	{
		static bool flag = false;
		static void SetTrue()
		{
			flag = true;
		}

		static void SetTrueIfFalse()
		{
			if (!flag)
				flag = true;
		}

		static void SetByThreeExp()
		{
			flag = !flag ? true : false;
		}

		static bool SameDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
		{
			if (dict1 == null && dict2 == null) return true;
			if (dict1 == null || dict2 == null) return false;
			if (dict1.Count != dict2.Count)
				return false;

			foreach (var x in dict1)
			{
				if (!dict2.TryGetValue(x.Key, out var y))
					return false;

				if (x.Value == null && y == null) continue;
				if (x.Value == null || y == null) return false;

				if (!x.Value.Equals(y))
					return false;
			}
			return true;
		}

		static int GetHashCode<TKey, TValue>(Dictionary<TKey, TValue> dict)
		{
			if (dict == null) return 0;
			return $"{dict.Count}:{string.Join('\n', dict.Select(x => $"{x.Key}:{x.Value.GetHashCode()}"))}".GetHashCode();
		}

		async static Task Main(string[] args)
		{
			Task t = await PrintNumbers(9).ConfigureAwait(false);
			Task t2 = await PrintNumbers(9).ConfigureAwait(false);
			Task t3 = await PrintNumbers(5).ConfigureAwait(false);
			await Task.WhenAll(t, t2, t3);
			ShowMessage("Done");
		}

		static async Task<Task> PrintNumbers(int max)
		{
			return await Task.Factory.StartNew(async () =>
			{
				for (int i = 0; i < max; i++)
				{
					ShowMessage(i.ToString());
					await Task.Delay(1000).ConfigureAwait(false);
				}
			}, TaskCreationOptions.LongRunning);
		}

		private static async void SocketHandler(Socket socket)
		{
			byte[] buffer = new byte[1024];
			ArraySegment<byte> bs = new ArraySegment<byte>(buffer);
			while (true)
			{
				ShowMessage("Reading");
				int len = await socket.ReceiveAsync(bs, SocketFlags.None).ConfigureAwait(false);
				ShowMessage($"Message.Length = {len}");

				var b2 = BitConverter.GetBytes(len);
				Array.Copy(b2, 0, buffer, 0, 4);
				ShowMessage("Sending");
				await socket.SendAsync(new ArraySegment<byte>(System.Text.Encoding.Default.GetBytes(len.ToString())), SocketFlags.None).ConfigureAwait(false);
				ShowMessage("Sent");

				ShowMessage("Responing");
				await socket.SendAsync(new ArraySegment<byte>(bs.Take(len).ToArray()), SocketFlags.None).ConfigureAwait(false);
				ShowMessage("Responsed");
			}
		}

		static void ShowMessage(string message)
		{
			Console.WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, message);
		}

		async static Task<Task> StartServerAsync()
		{
			return await Task.Factory.StartNew(async () =>
			{

				TcpListener tl = TcpListener.Create(8888);
				tl.Start();
				ShowMessage("server started");
				while (true)
				{
					Socket socket = await tl.AcceptSocketAsync();
					ShowMessage("connection created");

					_ = Task.Factory.StartNew(() => SocketHandler(socket), TaskCreationOptions.LongRunning);
				}
			}, TaskCreationOptions.LongRunning).ConfigureAwait(false);
		}

		static async Task<Task> StartClientAsync(int id)
		{
			return await Task.Factory.StartNew(async () =>
			{
				TcpClient tc = new TcpClient();
				await tc.ConnectAsync("127.0.0.1", 8888);
				ShowMessage($"Client-{id} connected");

				byte[] buffer = Encoding.Default.GetBytes("PING");

				await Task.Factory.StartNew(async () =>
				{
					NetworkStream networkStream = tc.GetStream();
					while (true)
					{
						byte[] readBuffer = new byte[1024];
						var len = await networkStream.ReadAsync(readBuffer);
						Console.WriteLine($"Client-{id}: Length of message = {len}");
					}
				}, TaskCreationOptions.LongRunning);
				_ = Task.Delay(3000)
				.ContinueWith(t =>
				{
					tc.Close();
				});
				while (true)
				{
					NetworkStream networkStream = tc.GetStream();

					await networkStream.WriteAsync(buffer, 0, buffer.Length);

					await Task.Delay(60000).ConfigureAwait(false);
				}
			}, TaskCreationOptions.LongRunning).ConfigureAwait(false);
		}
	}
}
