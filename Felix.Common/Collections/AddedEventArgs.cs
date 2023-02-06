namespace Felix.Common.Collections
{
	public class AddedEventArgs<T> : EventArgs
	{
		public T Item { get; }

		public AddedEventArgs(T item)
		{
			Item = item;
		}
	}
}
