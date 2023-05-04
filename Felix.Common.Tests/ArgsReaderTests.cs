using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Felix.Common.Tests
{
	[TestClass()]
	public class ArgsReaderTests
	{
		public static IEnumerable<object[]> Cases
		{
			get
			{
				return new[]
				{
					new object[] { new string[] { } },
					new object[] { new string[] { "a"} },
					new object[] { new string[] { "a","b"} },
				};
			}
		}

		[TestMethod]
		[DynamicData(nameof(Cases))]
		public void TryReadTest(string[] args)
		{
			var reader = new ArgsReader(args);
			int length = args.Length;
			var arg = string.Empty;

			for (int i = 0; i < length; i++)
			{
				Assert.IsTrue(reader.TryRead(out arg));
				Assert.AreEqual(args[i], arg);
			}

			Assert.IsFalse(reader.TryRead(out arg));
			Assert.AreEqual(string.Empty, arg);
		}

	}
}