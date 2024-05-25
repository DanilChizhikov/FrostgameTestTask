using UnityEngine;

namespace TestTask.Saves
{
    internal abstract class Serializer : ScriptableObject, ISerializer
    {
        public abstract string Serialize(object value);
        public abstract T DeSerialize<T>(string stringValue);
    }
}