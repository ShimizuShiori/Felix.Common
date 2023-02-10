namespace Felix.Common
{
	public class XmlHelper
	{
		public static T ToObject<T>(Stream stream, T defaultValue)
		{
			var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			var obj = serializer.Deserialize(stream);
			if (obj == null)
				return defaultValue;

			return (T)obj;
		}

		public static T ToObject<T>(string xmlFile, T defaultValue)
		{
			using (var stream = File.OpenRead(xmlFile))
			{
				return ToObject<T>(stream, defaultValue);
			}
		}
	}
}
