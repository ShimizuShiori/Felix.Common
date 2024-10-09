namespace Felix.Common.Scanner
{
    public interface IHandleResult
    {
        void Apply(IScanResultBuilder builder);
    }
}
