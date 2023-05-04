var searchPath = @"C:\git\wtg\Glow\Glow\CargoWiseOne\Configuration\Rules";

var ruleNameList = new string[]
{
	"IsGreaterThanOrEqualTo",
	"IsGreaterThan",
	"IsLessThan",
	"IsLessThanOrEqualTo"
};

var dir = new DirectoryInfo(searchPath);
foreach (var file in dir.EnumerateFiles("*.yaml", SearchOption.AllDirectories))
{
	var content = File.ReadAllText(file.FullName);
	bool matched = false;
	foreach (var ruleName in ruleNameList)
	{
		if (content.IndexOf($"methodName: {ruleName}") >= 0)
		{
			matched = true;
			break;
		}
	}

	if (!matched)
		continue;

	Console.WriteLine(file.Name);
}