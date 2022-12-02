namespace Felix.Common
{
	public static class CollectionEx
	{
		public static IDictionary<TKey, TValue> ToMap<TEle, TKey, TValue>(this IEnumerable<TEle> list, Func<TEle, (TKey key, TValue value)> func)
		{
			IDictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
			foreach (var item in list)
			{
				var (key, value) = func(item);
				result[key] = value;
			}
			return result;
		}
	}
}
