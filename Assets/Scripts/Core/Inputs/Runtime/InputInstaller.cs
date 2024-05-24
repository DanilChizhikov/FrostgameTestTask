using UnityEngine;
using Zenject;

namespace TestTask.Inputs
{
    [CreateAssetMenu(fileName = "InputInstaller", menuName = "Installers/InputInstaller")]
    internal sealed class InputInstaller : ScriptableObjectInstaller<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<InputHandler>().To<PlayerInputHandler>().AsCached();
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}