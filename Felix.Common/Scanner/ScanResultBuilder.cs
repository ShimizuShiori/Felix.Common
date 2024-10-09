
using System.Collections.ObjectModel;

namespace Felix.Common.Scanner
{
    public class ScanResultBuilder : IScanResultBuilder
    {
        readonly IDictionary<Type, ICollection<Type>> keyedComponents = new Dictionary<Type, ICollection<Type>>();

        public void AddKeyedComponent(Type keyType, Type componentType)
        {
            if (!keyedComponents.ContainsKey(keyType))
            {
                keyedComponents[keyType] = new List<Type>();
            }

            keyedComponents[keyType].Add(componentType);
        }

        public IScanResult Build()
        {
            return new ScanResult(
                new ReadOnlyDictionary<Type, IReadOnlyCollection<Type>>(
                    keyedComponents.ToDictionary(
                        x => x.Key,
                        x => (IReadOnlyCollection<Type>)new ReadOnlyCollection<Type>(x.Value.ToList())
                    )
                )
            );
            
        }
    }
}