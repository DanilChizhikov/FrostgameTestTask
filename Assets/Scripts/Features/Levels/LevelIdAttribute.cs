using System;
using TestTask.Utils;

namespace TestTask.Levels
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class LevelIdAttribute : StringIdAttribute
    {
    }
}