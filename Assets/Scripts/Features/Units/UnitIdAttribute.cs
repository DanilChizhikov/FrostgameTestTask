using System;
using TestTask.Utils;

namespace TestTask.Units
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class UnitIdAttribute : StringIdAttribute
    {
    }
}