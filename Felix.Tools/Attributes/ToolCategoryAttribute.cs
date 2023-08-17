namespace Felix.Tools.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	class ToolCategoryAttribute : Attribute
	{
		public string Category { get; private set; }

		public ToolCategoryAttribute(string category)
		{
			Category = category;
		}
	}
}
