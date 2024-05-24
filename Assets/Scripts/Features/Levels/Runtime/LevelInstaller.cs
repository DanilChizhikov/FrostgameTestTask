using UnityEngine;
using Zenject;

namespace TestTask.Levels
{
    [CreateAssetMenu(fileName = "LevelInstaller", menuName = "Installers/LevelInstaller")]
    internal sealed class LevelInstaller : ScriptableObjectInstaller<LevelInstaller>
    {
        [SerializeField] private LevelDatabase _database = default;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelDatabase>().FromInstance(_database).AsSingle();
            Container.Bind<LevelRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelViewProvider>().AsSingle();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle();
        }
    }
}