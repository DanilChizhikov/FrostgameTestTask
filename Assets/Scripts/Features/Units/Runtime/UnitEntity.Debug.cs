#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace TestTask.Units
{
    internal sealed partial class UnitEntity
    {
        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
            EditorUtility.SetDirty(this);
        }
    }
}
#endif