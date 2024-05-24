using UnityEngine;
using Zenject;

namespace TestTask.Core.Inputs.Runtime
{
    [CreateAssetMenu(fileName = "InputInstaller", menuName = "Installers/InputInstaller")]
    internal sealed class InputInstaller : ScriptableObjectInstaller<InputInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputService>().AsSingle();
        }
    }
}