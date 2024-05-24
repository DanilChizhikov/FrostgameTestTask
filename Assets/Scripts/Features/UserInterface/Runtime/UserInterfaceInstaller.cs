using UnityEngine;
using Zenject;

namespace TestTask.UserInterface
{
    [CreateAssetMenu(fileName = "UserInterfaceInstaller", menuName = "Installers/UserInterfaceInstaller")]
    internal sealed class UserInterfaceInstaller : ScriptableObjectInstaller<UserInterfaceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ScreenModel>().To<LoadingScreenModel>().AsCached();
            Container.Bind<ScreenModel>().To<MenuScreenModel>().AsCached();
            Container.Bind<ScreenModel>().To<GameplayScreenModel>().AsCached();
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
        }
    }
}