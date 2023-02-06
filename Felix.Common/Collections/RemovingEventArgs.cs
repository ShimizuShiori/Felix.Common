using Felix.Common.Events;

namespace Felix.Common.Collections
{
	public class RemovingEventArgs<T> : CancelableEventArgs
	{
		public T Item { get; }

		public RemovingEventArgs(T item)
		{
			Item = item;
		}
	}
}
