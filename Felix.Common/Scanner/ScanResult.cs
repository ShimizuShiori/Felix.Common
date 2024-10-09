namespace Felix.Common.Scanner
{
    public class ScanResult : IScanResult
    {
        readonly IReadOnlyDictionary<Type, IReadOnlyCollection<Type>> keyedComponents;

        public ScanResult(IReadOnlyDictionary<Type, IReadOnlyCollection<Type>> keyedComponents)
        {
            this.keyedComponents = keyedComponents;
        }

        public IEnumerable<Type> GetKeyedComponents(Type keyType)
        {
            if (keyedComponents.TryGetValue(keyType, out var components))
            {
                return components;
            }

            return Enumerable.Empty<Type>();
        }
    }
}
