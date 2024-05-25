using System.Linq;
using TestTask.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace TestTask.Units.Editor
{
    [CustomPropertyDrawer(typeof(UnitIdAttribute))]
    internal sealed class UnitIdDrawer : StringIdDrawer<UnitDatabase>
    {
        protected override GUIContent[] GetOptions(UnitDatabase data)
        {
            return data.Configs
                .Select(info => new GUIContent(info.Id))
                .ToArray();
        }
    }
}