using UnityEngine;
using Zenject;

namespace TestTask.StateMachine
{
    [CreateAssetMenu(menuName = "Installers/StateMachineInstaller", fileName = "StateMachineInstaller")]
    internal sealed class StateMachineInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }
    }
}