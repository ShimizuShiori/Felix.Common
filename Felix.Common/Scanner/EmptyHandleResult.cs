namespace Felix.Common.Scanner
{
    public class EmptyHandleResult : IHandleResult
    {
        private EmptyHandleResult()
        {

        }
        public void Apply(IScanResultBuilder builder)
        {
        }

        static readonly IHandleResult instance = new EmptyHandleResult();

        public static IHandleResult Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
