using NUnit.Framework;
using TestTask.Navigation;
using TestTask.Navigation.NavMesh;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Tests.Navigation
{
    public sealed class NavMeshPathfinderTests : PathfinderTests
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            var surface = NavMeshPlane.AddComponent<NavMeshSurface>();
            surface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            surface.BuildNavMesh();
        }
        
        [Test]
        public void Given_NavMeshPathfinder_When_FindPath_Then_PathIsNotEmpty()
        {
            var navigationAgent = new NavMeshAgent();
            IPathfinder pathfinder = GetFactory().CreatePathfinder(navigationAgent);
            Vector3 point = GetRandomPoint();
            
            navigationAgent.SetDestination(point);

            Assert.IsTrue(pathfinder.Path.Count > 0);
        }

        protected override IPathfinderFactory GetFactory()
        {
            return new NavMeshPathfinderFactory();
        }
    }
}