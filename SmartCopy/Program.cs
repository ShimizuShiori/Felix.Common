using Felix.Common;

var argsReader = new ArgsReader(args);


var currentPath = argsReader.Read(() => InputArgs("Source Folder > "));
var targetPath = argsReader.Read(() => InputArgs("Target Folder > "));
var comparer = argsReader.Read(() => InputArgs(@"Comparer
	t: Time
	l: Length
	b: Both
	(default): Both
> "));
var reportType = argsReader.Read(() => InputArgs(@"Report Type
	d: Detail
	s: Summary
	(default): Summary
> "));

var currentDir = new DirectoryInfo(currentPath);
var reporter = reportType.ToLower() == "d"
	? ReportDetail
	: CreateSummaryReporter();

Func<FileInfo, FileInfo, bool> comparerFunc = comparer.ToLower() switch
{
	"t" => CompareTime,
	"l" => CompareLength,
	_ => CompareBoth,
};

foreach (var file in currentDir.EnumerateFiles("*", SearchOption.AllDirectories))
{
	var relPath = Path.GetRelativePath(currentPath, file.FullName);
	var targetFilePath = Path.Combine(targetPath, relPath);
	var targetFileInfo = new FileInfo(targetFilePath);
	if (targetFileInfo.Directory == null)
		continue;
	if (!targetFileInfo.Exists)
	{
		if (!targetFileInfo.Directory.Exists)
			targetFileInfo.Directory.Create();

		File.Copy(file.FullName, targetFilePath);
		reporter(targetFilePath, Result.Created);
		continue;
	}

	var attr = File.GetAttributes(targetFileInfo.Directory.FullName);
	if ((attr & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
	{
		reporter(targetFilePath, Result.Skipped);
		continue;
	}

	if (comparerFunc(file, targetFileInfo))
	{
		reporter(targetFilePath, Result.Skipped);
		continue;
	}

	File.Copy(file.FullName, targetFilePath, true);
	reporter(targetFilePath, Result.Copied);
}
Console.WriteLine("Done");


string InputArgs(string label)
{
	Console.Write(label);
	return Console.ReadLine() ?? string.Empty;
}

void ReportDetail(string fileName, Result result)
{
	Console.WriteLine($"{fileName} {result}");
}

bool CompareTime(FileInfo f1, FileInfo f2)
{
	return f1.LastWriteTime == f2.LastWriteTime;
}

bool CompareLength(FileInfo f1, FileInfo f2)
{
	return f1.Length == f2.Length;
}

bool CompareBoth(FileInfo f1, FileInfo f2)
{
	return CompareTime(f1, f2) && CompareLength(f1, f2);
}

Action<string, Result> CreateSummaryReporter()
{
	var createdCount = 0;
	var copiedCount = 0;
	var skippedCount = 0;
	var top = new Lazy<int>(() => Console.CursorTop);

	void Report(string fileName, Result result)
	{
		Action plus = result switch
		{
			Result.Created => () => createdCount++,
			Result.Copied => () => copiedCount++,
			Result.Skipped => () => skippedCount++,
			_ => () => { },
		};
		plus();
		Console.CursorTop = top.Value;
		Console.WriteLine($"Create: {createdCount};\nCopied: {copiedCount}\nSkipped: {skippedCount}");
	}

	return Report;
}

enum Result
{
	Created,
	Copied,
	Skipped,
}