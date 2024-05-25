using UnityEngine;
using Zenject;

namespace TestTask.Units
{
    [CreateAssetMenu(fileName = nameof(UnitInstaller), menuName = "Installers/" + nameof(UnitInstaller))]
    internal sealed class UnitInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private UnitDatabase _unitDatabase = default;
        [SerializeField] private EntityDatabase _entityDatabase = default;

        public override void InstallBindings()
        {
            Container.BindInstance(_unitDatabase).AsSingle();
            Container.BindInstance(_entityDatabase).AsSingle();
            Container.Bind<UnitRepository>().AsSingle();
            Container.Bind<IUnitComponentService>()
                .FromSubContainerResolve()
                .ByInstaller<ComponentInstaller>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<AnimationSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PathMoveSystem>().AsSingle().NonLazy();
            Container.Bind<IUnitIdService>().To<UnitIdService>().AsSingle();
            Container.Bind<IUnitFactory>().To<UnitFactory>().AsSingle();
        }
    }
}