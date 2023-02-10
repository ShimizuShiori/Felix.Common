using System.Text;

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

		public static string JoinAsString(this IEnumerable<string> list, string joiner)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in list)
			{
				sb.Append(item);
				sb.Append(joiner);
			}
			sb.Length = sb.Length - joiner.Length;
			return sb.ToString();
		}
	}
}
