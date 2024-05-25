using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Saves.Extensions
{
    public static class CollectionExtensions
    {
        public static IReadOnlyList<SaveVector3> ToSaveVector3List(this IReadOnlyList<Vector3> list)
        {
            var result = new List<SaveVector3>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(new SaveVector3(list[i]));
            }
            
            return result;
        }
        
        public static IReadOnlyList<Vector3> ToVector3List(this IReadOnlyList<SaveVector3> list)
        {
            var result = new List<Vector3>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[i].ToVector3());
            }
            
            return result;
        }
    }
}