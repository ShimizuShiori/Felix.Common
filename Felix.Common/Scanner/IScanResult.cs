namespace Felix.Common.Scanner
{
    public interface IScanResult
    {
        public IEnumerable<Type> GetKeyedComponents(Type keyType);
    }

    public static class ScanResultExtensions
    {
        public static IEnumerable<T> GetKeyedComponents<T>(this IScanResult scanResult)
        {
            return scanResult.GetKeyedComponents(typeof(T)).Cast<T>();
        }
    }
}
