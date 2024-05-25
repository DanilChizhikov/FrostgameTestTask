using System.Linq;
using TestTask.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace TestTask.Player.Editor
{
    [CustomPropertyDrawer(typeof(PlayerIdAttribute))]
    internal sealed class PlayerIdDrawer : StringIdDrawer<PlayerDatabase>
    {
        protected override GUIContent[] GetOptions(PlayerDatabase data)
        {
            return data.Infos
                .Select(info => new GUIContent(info.Id))
                .ToArray();
        }
    }
}