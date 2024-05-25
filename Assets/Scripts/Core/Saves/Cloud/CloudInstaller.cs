using UnityEngine;
using Zenject;

namespace TestTask.Saves
{
    [CreateAssetMenu(fileName = nameof(CloudInstaller), menuName = "Installers/" + nameof(CloudInstaller))]
    internal sealed class CloudInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveStorage>().To<UnityCloudSaveStorage>().AsSingle();
        }
    }
}