using System;
using TestTask.Utils;

namespace TestTask.Units
{
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class EntityIdAttribute : StringIdAttribute
    {
    }
}