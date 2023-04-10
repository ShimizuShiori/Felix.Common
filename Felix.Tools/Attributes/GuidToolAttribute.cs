namespace Felix.Tools.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	class GuidToolAttribute : TextToolAttribute
	{
		public GuidToolAttribute(string name, string category) : base(name, category, @"^[\d\w]{8}-[\w\d]{4}-[\d\w]{4}-[\d\w]{4}-[\d\w]{12}$")
		{
		}
	}
}
