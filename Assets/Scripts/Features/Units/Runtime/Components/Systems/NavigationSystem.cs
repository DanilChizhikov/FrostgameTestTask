using System;
using TestTask.Inputs;
using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Units
{
    internal sealed class NavigationSystem : UnitComponentSystem<QueuedNavigationComponent>, IPlayerInputListener
    {
        private IDisposable _inputSubscire;
        
        public NavigationSystem(IUnitComponentService componentService, IInputService inputService) : base(componentService)
        {
            _inputSubscire = inputService.Subscribe(this);
        }

        public void OnMove(Vector2 screenPoint)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPoint);
            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                return;
            }

            if (!NavMesh.Raycast(ray.origin, hit.point, out NavMeshHit navMeshHit, NavMesh.AllAreas))
            {
                return;
            }
            
            while (TryMoveNext(out QueuedNavigationComponent component))
            {
                component.SetDestination(navMeshHit.position); 
            }
        }

        public override void Dispose()
        {
            _inputSubscire?.Dispose();
            base.Dispose();
        }
    }
}