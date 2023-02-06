using Felix.Common.Events;

namespace Felix.Common.Collections
{
	public class RemovedEventArgs<T> : CancelableEventArgs
	{
		public T Item { get; }

		public RemovedEventArgs(T item)
		{
			Item = item;
		}
	}
}
