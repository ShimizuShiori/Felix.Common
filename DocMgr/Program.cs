using DocMgr;
using Felix.Common;

var argsReader = new ArgsReader(args);

var action = argsReader.Read(() => ConsoleEx.Input("Action: ")).ToLower();

var methods = typeof(Handlers).GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
	.ToMap(m => (m.Name.ToLower(), m));

if (!methods.TryGetValue(action, out var method))
	return;

var ps = method.GetParameters();
var vs = new object[ps.Length];

for (int i = 0; i < ps.Length; i++)
{
	var p = ps[i];
	var v = argsReader.Read(() => ConsoleEx.Input($"{p.Name}: "));
	vs[i] = Convert.ChangeType(v, p.ParameterType);
}

method.Invoke(null, vs);