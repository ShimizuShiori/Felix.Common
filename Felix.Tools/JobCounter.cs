namespace Felix.Tools
{
	class JobCounter
	{
		int value = 0;

		public void Increment()
		{
			Interlocked.Increment(ref value);
		}

		public void Decrement()
		{
			Interlocked.Decrement(ref value);
		}

		public bool IsEmpty()
		{
			return Interlocked.CompareExchange(ref value, 0, 0) == 0;
		}
	}
}
