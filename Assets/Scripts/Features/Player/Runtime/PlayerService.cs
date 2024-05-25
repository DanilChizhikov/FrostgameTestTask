using System;
using Cysharp.Threading.Tasks;
using TestTask.Units;
using UnityEngine;

namespace TestTask.Player
{
    internal sealed class PlayerService : IPlayerService
    {
        public event Action OnPlayerCreated;
        public event Action OnPlayerPreRemoved;

        private readonly IUnitFactory _unitFactory;
        private readonly PlayerRepository _repository;
        
        private uint _playerId;
        private bool _hasPlayer;
        
        public string SelectedPlayer { get; }

        public PlayerService(PlayerConfig config, IUnitFactory unitFactory, PlayerRepository repository)
        {
            _unitFactory = unitFactory;
            _repository = repository;
            SelectedPlayer = config.Player;
            _playerId = uint.MaxValue;
            _hasPlayer = false;
        }
        
        public async UniTask CreatePlayerAsync(Vector3 position, Quaternion rotation)
        {
            if (!_repository.TryGetPlayer(SelectedPlayer, out string unitId))
            {
                throw new Exception($"Player {SelectedPlayer} not found");
            }
            
            _playerId = _unitFactory.Create(unitId, position, rotation);
            _hasPlayer = true;
            OnPlayerCreated?.Invoke();
        }

        public bool TryGetPlayer(out uint playerId)
        {
            playerId = _playerId;
            return _hasPlayer;
        }

        public async UniTask RemovePlayerAsync()
        {
            if (!_hasPlayer)
            {
                return;
            }
            
            OnPlayerPreRemoved?.Invoke();
            _unitFactory.RemoveUnit(_playerId);
            _playerId = uint.MaxValue;
            _hasPlayer = false;
        }
    }
}