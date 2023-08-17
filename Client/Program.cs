namespace Demo
{
	interface ITranslator
	{
		string Translate(string text);
	}

	class Chinese : ITranslator
	{
		public string Translate(string text)
		{
			return "你好";
		}
	}

	class English : ITranslator
	{
		public string Translate(string text)
		{
			return "Hello";
		}
	}

	class Screen
	{
		readonly ITranslator translator;

		public Screen(ITranslator translator)
		{
			this.translator = translator;
		}

		public void ShowHello()
		{
			Console.WriteLine(translator.Translate("Hello"));
		}
	}

	internal class Program
	{
		async static Task Main(string[] args)
		{
			// 这里怎么写 ?
			//var s = new Screen();
			//s.ShowHello();
		}
	}
}