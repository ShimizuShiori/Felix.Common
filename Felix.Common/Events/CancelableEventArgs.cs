namespace Felix.Common.Events
{
	public class CancelableEventArgs : EventArgs, ICancelable
	{
		bool isCancenlled = false;

		public bool IsCancelled => isCancenlled;

		public void Cancel()
		{
			this.isCancenlled = true;
		}
	}
}
