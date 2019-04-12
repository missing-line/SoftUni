using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        StringBuilder builder = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            builder.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} have to be private!");
        }
        return builder.ToString().Trim();
    }
}

