using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace TestTask.Utils.Editor
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    internal sealed class SceneDrawer : PropertyDrawer
    {
        private const string ScenePattern = @".+\/(.+)\.unity";
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    DrawForIntField(position, property, label);
                    break;
                
                case SerializedPropertyType.String:
                    DrawForStringField(position, property, label);
                    break;
                
                default:
                    EditorGUI.HelpBox(position, "Property must be of type Integer or String", MessageType.Error);
                    break;
            }
        }

        private static void DrawForIntField(Rect position, SerializedProperty property, GUIContent label)
        {
            using var scope = new EditorGUI.ChangeCheckScope();
            int lastSelected = property.intValue;
            GUIContent[] options = GetOptions();
            int selectedIndex = EditorGUI.Popup(position, label, lastSelected, options);
            if (scope.changed && selectedIndex != lastSelected)
            {
                property.intValue = selectedIndex;
            }
        }
        
        private static void DrawForStringField(Rect position, SerializedProperty property, GUIContent label)
        {
            using var scope = new EditorGUI.ChangeCheckScope();
            GUIContent[] options = GetOptions();
            int lastSelected = IndexOf(property.stringValue, options);
            int selectedIndex = EditorGUI.Popup(position, label, lastSelected, options);
            if (scope.changed && selectedIndex != lastSelected)
            {
                property.stringValue = options[selectedIndex].text;
            }
        }
        
        private static int IndexOf(string stringValue, GUIContent[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (options[i].text.Equals(stringValue))
                {
                    return i;
                }
            }
            
            return -1;
        }

        private static GUIContent[] GetOptions()
        {
            string[] scenes = GetScenes();
            return scenes.Select(s => new GUIContent(s)).ToArray();
        }

        private static string[] GetScenes() => EditorBuildSettings.scenes.Where(s => s.enabled)
            .Select(s => Regex.Match(s.path, ScenePattern).Groups[1].Value)
            .ToArray();
    }
}