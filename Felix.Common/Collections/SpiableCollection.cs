using Felix.Common.Events;
using System.Collections;

namespace Felix.Common.Collections
{
	public class SpiableCollection<T> : ISpiableCollection<T>
	{
		readonly ICollection<T> rawCollection;

		public SpiableCollection(ICollection<T> rawCollection)
		{
			this.rawCollection = rawCollection;
		}

		public int Count => rawCollection.Count;

		public bool IsReadOnly => rawCollection.IsReadOnly;

		public event EventHandler<AddingEventArgs<T>> Adding;
		public event EventHandler<AddedEventArgs<T>> Added;
		public event EventHandler<RemovingEventArgs<T>> Removing;
		public event EventHandler<RemovedEventArgs<T>> Removed;
		public event EventHandler<CancelableEventArgs> Clearing;
		public event EventHandler<EventArgs> Cleared;

		public void Add(T item)
		{
			if (!OnAdding(item))
				return;

			rawCollection.Add(item);

			OnAdded(item);
		}

		protected virtual void OnAdded(T item)
		{
			this.Added?.Invoke(this, new AddedEventArgs<T>(item));
		}

		protected virtual bool OnAdding(T item)
		{
			var e = new AddingEventArgs<T>(item);
			this.Adding?.Invoke(this, e);
			return !e.IsCancelled;
		}

		public void Clear()
		{
			if (!this.OnClearing())
				return;

			rawCollection.Clear();
			this.OnCleared();
		}

		protected virtual void OnCleared()
		{
			this.Cleared?.Invoke(this, EventArgs.Empty);
		}

		private bool OnClearing()
		{
			var e = new CancelableEventArgs();
			this.Clearing?.Invoke(this, e);
			return !e.IsCancelled;
		}

		public bool Contains(T item)
		{
			return rawCollection.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			rawCollection.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return rawCollection.GetEnumerator();
		}

		public bool Remove(T item)
		{
			if (this.OnRemoving(item))
				return false;

			var r = rawCollection.Remove(item);
			this.OnRemoved(item);
			return r;
		}

		protected virtual void OnRemoved(T item)
		{
			this.Removed?.Invoke(this, new RemovedEventArgs<T>(item));
		}

		private bool OnRemoving(T item)
		{
			var e = new RemovingEventArgs<T>(item);
			this.Removing?.Invoke(this, e);
			return !e.IsCancelled;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return rawCollection.GetEnumerator();
		}
	}
}
