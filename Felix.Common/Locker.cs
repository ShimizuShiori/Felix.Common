namespace Felix.Common
{
	public static class Locker
	{
		public static void RunDoubleChecked(object locker, Func<bool> predicate, Action action)
		{
			if (predicate())
				lock (locker)
					if (predicate())
						action();
		}
	}
}
