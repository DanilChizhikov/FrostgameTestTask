using UnityEngine;
using Zenject;

namespace TestTask.Navigation.NavMesh
{
    [CreateAssetMenu(fileName = nameof(NavMeshPathfindInstaller), menuName = "Installers/" + nameof(NavMeshPathfindInstaller))]
    internal sealed class NavMeshPathfindInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPathfinderFactory>().To<NavMeshPathfinderFactory>().AsSingle();
        }
    }
}