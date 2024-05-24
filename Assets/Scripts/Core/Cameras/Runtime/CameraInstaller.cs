using UnityEngine;
using Zenject;

namespace TestTask.Cameras.Runtime
{
    [CreateAssetMenu(fileName = "CameraInstaller", menuName = "Installers/CameraInstaller")]
    internal sealed class CameraInstaller : ScriptableObjectInstaller<CameraInstaller>
    {
        [SerializeField] private CameraDatabase _database = default;
        
        public override void InstallBindings()
        {
            Container.Bind<CameraDatabase>().FromInstance(_database).AsSingle();
            Container.Bind<CameraRepository>().AsSingle();
            Container.BindInterfacesTo<CameraService>().AsSingle();
        }
    }
}