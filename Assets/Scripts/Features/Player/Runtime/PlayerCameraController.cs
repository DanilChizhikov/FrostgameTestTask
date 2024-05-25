using System;
using TestTask.Cameras;
using TestTask.Cameras.Configs;
using TestTask.Units;

namespace TestTask.Player
{
    internal sealed class PlayerCameraController : IDisposable
    {
        private readonly string _cameraId;
        private readonly IPlayerService _playerService;
        private readonly ICameraService _cameraService;
        private readonly IUnitIdService _idService;

        public PlayerCameraController(PlayerConfig config, IPlayerService playerService, ICameraService cameraService, IUnitIdService idService)
        {
            _cameraId = config.CameraId;
            _playerService = playerService;
            _cameraService = cameraService;
            _idService = idService;
            playerService.OnPlayerCreated += PlayerCreatedCallback;
            playerService.OnPlayerPreRemoved += PlayerPreRemovedCallback;
        }

        public void Dispose()
        {
            _playerService.OnPlayerCreated -= PlayerCreatedCallback;
            _playerService.OnPlayerPreRemoved -= PlayerPreRemovedCallback;
        }
        
        private void PlayerCreatedCallback()
        {
            if (!_playerService.TryGetPlayer(out uint playerId) ||
                !_idService.TryGetUnit(playerId, out IUnitEntity player))
            {
                return;
            }

            _cameraService.TrySetup(new FollowConfig
            {
                CameraId = _cameraId,
                FollowTarget = player.Rigidbody.transform,
            });
        }
        
        private void PlayerPreRemovedCallback()
        {
            if (!_playerService.TryGetPlayer(out _))
            {
                return;
            }
            
            _cameraService.RemoveCamera();
        }
    }
}