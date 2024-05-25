using System;
using TestTask.Utils;

namespace TestTask.Units
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class UnitIdAttribute : StringIdAttribute
    {
    }
}