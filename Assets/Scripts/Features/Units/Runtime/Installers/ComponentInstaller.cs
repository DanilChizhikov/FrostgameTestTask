using Zenject;

namespace TestTask.Units
{
    internal sealed class ComponentInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallFactories();
            Container.Bind<IUnitComponentService>().To<UnitComponentService>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<ComponentFactory>().To<AnimationComponentFactory>().AsTransient();
            Container.Bind<ComponentFactory>().To<PathMoveComponentFactory>().AsTransient();
        }
    }
}