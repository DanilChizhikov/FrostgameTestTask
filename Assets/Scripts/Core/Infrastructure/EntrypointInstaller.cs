using UnityEngine;
using Zenject;

namespace TestTask.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(EntrypointInstaller), menuName = "Installers/" + nameof(EntrypointInstaller))]
    internal sealed class EntrypointInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().To<Entrypoint>().AsSingle().NonLazy();
        }
    }
}