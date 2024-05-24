using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TestTask.Utils.Editor
{
    public abstract class StringIdDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "Property must be of type String", MessageType.Error);
                return;
            }
            
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                GUIContent[] options = GetOptions();
                int lastSelectedIndex = GetLastSelectedIndex(options, property.stringValue);
                int selectedIndex = EditorGUI.Popup(position, label, lastSelectedIndex, options);
                if (scope.changed && selectedIndex != lastSelectedIndex)
                {
                    property.stringValue = options[selectedIndex].text;
                }
            }
        }

        protected abstract GUIContent[] GetOptions();

        private int GetLastSelectedIndex(IReadOnlyList<GUIContent> options, string currentValue)
        {
            int result = -1;
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i].text == currentValue)
                {
                    result = i;
                    break;
                }
            }
            
            return result;
        }
    }
    
    public abstract class StringIdDrawer<T> : StringIdDrawer
        where T : ScriptableObject
    {
        protected sealed override GUIContent[] GetOptions()
        {
            T data = GetData();
            if (data == null)
            {
                return new GUIContent[0];
            }
            
            return GetOptions(data);
        }

        protected abstract GUIContent[] GetOptions(T data);

        private T GetData()
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
                if (asset is T genericAsset)
                {
                    return genericAsset;
                }
            }

            return null;
        }
    }
}