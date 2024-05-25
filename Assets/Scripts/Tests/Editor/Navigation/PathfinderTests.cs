using NUnit.Framework;
using TestTask.Navigation;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TestTask.Tests.Navigation
{
    public abstract class PathfinderTests
    {
        protected GameObject NavMeshPlane { get; private set; }
        
        [SetUp]
        public virtual void Setup()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            NavMeshPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            NavMeshPlane.transform.position = Vector3.zero;
            NavMeshPlane.transform.localScale = new Vector3(10f, 1f, 10f);
        }

        [TearDown]
        public virtual void TearDown()
        {
            Object.DestroyImmediate(NavMeshPlane);
        }
        
        protected abstract IPathfinderFactory GetFactory();
        
        protected Vector3 GetRandomPoint()
        {
            return new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        }
    }
}