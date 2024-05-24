using System.Linq;
using TestTask.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace TestTask.Levels.Editor
{
    [CustomPropertyDrawer(typeof(LevelIdAttribute))]
    internal sealed class LevelIdDrawer : StringIdDrawer<LevelDatabase>
    {
        protected override GUIContent[] GetOptions(LevelDatabase data)
        {
            return data.Infos
                .Select(info => new GUIContent(info.Id))
                .ToArray();
        }
    }
}