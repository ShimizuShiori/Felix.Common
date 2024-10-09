namespace Felix.Common.Scanner
{
    public interface IScanResultBuilder
    {
        void AddKeyedComponent(Type keyType, Type componentType);

        IScanResult Build();
    }
}
