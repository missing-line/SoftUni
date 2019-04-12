using System;
using System.Linq;
using System.Reflection;

[SoftUni("Ventsi")]
public class StartUp
{
    [SoftUni("Gosho")]
    public static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type typeClass = typeof(StartUp);
        var methods = typeClass.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(x=>x.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodInfo.GetCustomAttribute<SoftUniAttribute>();
                if (attrs != null)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attrs.Name}");
                }
            }
        }
    }
}
