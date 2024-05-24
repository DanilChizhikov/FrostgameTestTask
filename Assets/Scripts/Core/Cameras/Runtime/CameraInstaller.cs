using UnityEngine;
using Zenject;

namespace TestTask.Cameras.Runtime
{
    internal sealed class CameraInstaller : ScriptableObjectInstaller<CameraInstaller>
    {
        [SerializeField] private CameraDatabase _database = default;
        
        public override void InstallBindings()
        {
            Container.Bind<CameraDatabase>().FromInstance(_database).AsSingle();
            Container.BindInterfacesTo<CameraService>().AsSingle();
        }
    }
}