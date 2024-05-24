using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTask.Levels
{
    internal static class SceneExtensions
    {
        public static ILevelView GetLevelView(this Scene scene)
        {
            ILevelView result = null;
            GameObject[] gameObjects = scene.GetRootGameObjects();
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i].TryGetComponent(out result))
                {
                    break;
                }
            }
            
            return result;
        }
    }
}