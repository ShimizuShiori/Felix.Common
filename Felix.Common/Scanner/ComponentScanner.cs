using System.Reflection;

namespace Felix.Common.Scanner
{
    public class ComponentScanner : IComponentScanner
    {
        readonly ICollection<Assembly> assemblies;
        readonly ICollection<IComponentHandler> handlers;

        public ComponentScanner()
        {
            handlers = new List<IComponentHandler>();
            assemblies = new List<Assembly>();
        }

        public void AddHandler(IComponentHandler handler)
        {
            handlers.Add(handler);
        }

        public IScanResult Scan()
        {
            var resultBuilder = new ScanResultBuilder();

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    foreach (var handler in handlers)
                    {
                        var handleResult = handler.Handle(type);
                        handleResult.Apply(resultBuilder);
                    }
                }
            }

            return resultBuilder.Build();
        }
    }
}
