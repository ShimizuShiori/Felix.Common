using Felix.Common.Events;

namespace Felix.Common.Collections
{
	internal interface ISpiableCollection<T> : ICollection<T>
	{
		event EventHandler<AddingEventArgs<T>> Adding;
		event EventHandler<AddedEventArgs<T>> Added;
		event EventHandler<RemovingEventArgs<T>> Removing;
		event EventHandler<RemovedEventArgs<T>> Removed;
		event EventHandler<CancelableEventArgs> Clearing;
		event EventHandler<EventArgs> Cleared;
	}
}
