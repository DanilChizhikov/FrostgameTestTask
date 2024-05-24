using System;
using UnityEngine;

namespace TestTask.Utils
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class SceneAttribute : PropertyAttribute
    {
    }
}