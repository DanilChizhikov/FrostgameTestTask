using UnityEngine;
using Zenject;

namespace TestTask.Saves
{
    [CreateAssetMenu(fileName = nameof(SaveInstaller), menuName = "Installers/" + nameof(SaveInstaller))]
    internal sealed class SaveInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Serializer _serializer = default;

        public override void InstallBindings()
        {
            Container.Bind<ISerializer>().FromInstance(_serializer).AsSingle();
            Container.Bind<ISaveService>().To<SaveService>().AsSingle();
        }
    }
}