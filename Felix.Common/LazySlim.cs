namespace Felix.Common
{
    public class LazySlim<T>
    {
        private readonly Func<T> _factory;
        private T? _value;
        private bool _isValueCreated;

        public LazySlim(Func<T> factory)
        {
            _factory = factory;
        }

        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    _value = _factory();
                    _isValueCreated = true;
                }
                return _value!;
            }
        }
    }
}
