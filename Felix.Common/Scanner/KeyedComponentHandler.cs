namespace Felix.Common.Scanner
{
    public class KeyedComponentHandler : IComponentHandler
    {
        readonly Type keyedType;

        public KeyedComponentHandler(Type keyedType)
        {
            this.keyedType = keyedType;
        }

        public IHandleResult Handle(Type type)
        {
            if (keyedType.IsAssignableFrom(type))
            {
                return new KeyedComponentResult(keyedType, type);
            }
            return EmptyHandleResult.Instance;
        }
    }
}
