using Zenject;

namespace TestTask.Units
{
    internal sealed class ComponentInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallSystems();
            Container.Bind<IUnitComponentService>().To<UnitComponentService>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<ComponentFactory>().To<AnimationComponentFactory>().AsTransient();
            Container.Bind<ComponentFactory>().To<QueuedNavigationComponentFactory>().AsTransient();
            Container.Bind<ComponentFactory>().To<MovePathComponentFactory>().AsTransient();
            Container.Bind<ComponentFactory>().To<RotateComponentFactory>().AsTransient();
        }

        private void InstallSystems()
        {
            Container.BindInterfacesTo<AnimationSystem>().AsSingle();
            Container.BindInterfacesTo<PathMoveSystem>().AsSingle();
            Container.BindInterfacesTo<RotateSystem>().AsSingle();
            Container.BindInterfacesTo<NavigationSystem>().AsSingle();
        }
    }
}