using UnityEngine;
using Zenject;

namespace TestTask.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerInstaller), menuName = "Installers/" + nameof(PlayerInstaller))]
    internal sealed class PlayerInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig = default;
        [SerializeField] private PlayerDatabase _database = default;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerConfig).AsSingle();
            Container.BindInstance(_database).AsSingle();
            Container.Bind<PlayerRepository>().AsSingle();
            Container.BindInterfacesTo<PlayerCameraController>().AsSingle();
            Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
        }
    }
}