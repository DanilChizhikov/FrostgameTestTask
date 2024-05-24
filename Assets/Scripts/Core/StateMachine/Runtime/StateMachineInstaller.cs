using TestTask.StateMachine.States;
using UnityEngine;
using Zenject;

namespace TestTask.StateMachine
{
    [CreateAssetMenu(menuName = "Installers/StateMachineInstaller", fileName = "StateMachineInstaller")]
    internal sealed class StateMachineInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IState>().To<BootstrapState>().AsTransient();
            Container.Bind<IState>().To<MenuState>().AsTransient();
            Container.Bind<IState>().To<GameplayState>().AsTransient();
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
    }
}