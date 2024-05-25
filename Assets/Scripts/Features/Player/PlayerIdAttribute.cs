using System;
using TestTask.Utils;

namespace TestTask.Player
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class PlayerIdAttribute : StringIdAttribute
    {
    }
}