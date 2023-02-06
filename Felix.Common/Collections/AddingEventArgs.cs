using Felix.Common.Events;

namespace Felix.Common.Collections
{
	public class AddingEventArgs<T> : CancelableEventArgs
	{
		public T Item { get; }

		public AddingEventArgs(T item)
		{
			Item = item;
		}
	}
}
