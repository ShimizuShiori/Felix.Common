namespace Felix.Common
{
	interface ICancelable
	{
		void Cancel();
		bool IsCancelled { get; }
	}
}
