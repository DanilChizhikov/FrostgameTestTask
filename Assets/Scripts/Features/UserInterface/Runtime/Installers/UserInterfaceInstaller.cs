using UnityEngine;
using Zenject;

namespace TestTask.UserInterface
{
    [CreateAssetMenu(fileName = "UserInterfaceInstaller", menuName = "Installers/UserInterfaceInstaller")]
    internal sealed class UserInterfaceInstaller : ScriptableObjectInstaller<UserInterfaceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ScreenModel>().To<LoadingScreenModel>().AsTransient();
            Container.Bind<ScreenModel>().To<MenuScreenModel>().AsTransient();
            Container.Bind<ScreenModel>().To<GameplayScreenModel>().AsTransient();
            Container.Bind<LoadingScreenViewModel>().ToSelf().AsSingle();
            Container.Bind<MenuScreenViewModel>().ToSelf().AsSingle();
            Container.Bind<GameplayScreenViewModel>().ToSelf().AsSingle();
            Container.Bind<ScreenModelProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
        }
    }
}