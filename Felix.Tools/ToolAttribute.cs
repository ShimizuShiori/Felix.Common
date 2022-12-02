namespace Felix.Tools
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ToolAttribute : Attribute
	{
		public string Name { get; }
		public string Category { get; }

		public ToolAttribute(string name, string category)
		{
			Name = name;
			Category = category;
		}

		static readonly ToolAttribute empty = new ToolAttribute(string.Empty, string.Empty);

		public static ToolAttribute Empty { get => empty; }

		public static bool IsEmpty(ToolAttribute toolAttribute)
		{
			return toolAttribute == empty;
		}
	}
}
