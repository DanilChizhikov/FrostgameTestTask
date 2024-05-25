using System.Linq;
using TestTask.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace TestTask.Units.Editor
{
    [CustomPropertyDrawer(typeof(EntityIdAttribute))]
    internal sealed class EntityIdDrawer : StringIdDrawer<EntityDatabase>
    {
        protected override GUIContent[] GetOptions(EntityDatabase data)
        {
            return data.Infos
                .Select(info => new GUIContent(info.Id))
                .ToArray();
        }
    }
}