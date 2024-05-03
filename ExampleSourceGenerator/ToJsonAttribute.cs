using System;

namespace ExampleSourceGenerator
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ToJsonAttribute : Attribute
    {
    }
}
