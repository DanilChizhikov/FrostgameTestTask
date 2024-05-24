using System.Linq;
using TestTask.Cameras.Runtime;
using TestTask.Utils.Editor;
using UnityEditor;
using UnityEngine;

namespace TestTask.Cameras.Editor
{
    [CustomPropertyDrawer(typeof(CameraIdAttribute))]
    internal sealed class CameraIdDrawer : StringIdDrawer<CameraDatabase>
    {
        protected override GUIContent[] GetOptions(CameraDatabase data)
        {
            return data
                .Infos
                .Select(x => new GUIContent(x.Id))
                .ToArray();
        }
    }
}