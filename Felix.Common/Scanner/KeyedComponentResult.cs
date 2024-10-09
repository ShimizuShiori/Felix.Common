namespace Felix.Common.Scanner
{
    public class KeyedComponentResult : IHandleResult
    {
        readonly Type keyedType;
        readonly Type componentType;

        public KeyedComponentResult(Type keyedType, Type componentType)
        {
            this.keyedType = keyedType;
            this.componentType = componentType;
        }

        public void Apply(IScanResultBuilder builder)
        {
            builder.AddKeyedComponent(keyedType, componentType);
        }
    }
}
