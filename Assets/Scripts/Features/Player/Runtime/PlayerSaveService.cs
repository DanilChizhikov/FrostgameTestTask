using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TestTask.Saves;
using TestTask.Saves.Extensions;
using TestTask.Units;
using UnityEngine;

namespace TestTask.Player
{
    internal sealed class PlayerSaveService : IPlayerSaveService
    {
        [Serializable]
        private struct PlayerSaveData
        {
            public IReadOnlyList<SaveVector3> NavigationQueue { get; set; }
            public SaveVector3 CurrentPosition { get; set; }
            public SaveVector3 CurrentDirection { get; set; }
            public bool IsValid { get; set; }
        }
        
        private const string PlayerSaveKey = "PlayerSaveKey";

        private readonly ISaveService _saveService;
        private readonly IPlayerService _playerService;
        private readonly IUnitComponentService _componentService;

        public PlayerSaveService(IPlayerService playerService, IUnitComponentService componentService, ISaveService saveService)
        {
            _playerService = playerService;
            _componentService = componentService;
            _saveService = saveService;
        }
        
        public async UniTask SaveAsync()
        {
            if (!_playerService.TryGetPlayer(out uint playerId))
            {
                return;
            }

            if (_componentService.TryGetComponent(playerId, out IPathMoveComponent pathMoveComponent))
            {
                var saveData = new PlayerSaveData
                {
                    NavigationQueue = pathMoveComponent.NavigationQueue.ToSaveVector3List(),
                    CurrentPosition = new SaveVector3(pathMoveComponent.CurrentPosition),
                    CurrentDirection = new SaveVector3(pathMoveComponent.CurrentDirection),
                    IsValid = true,
                };
                
                await _saveService.SaveAsync(PlayerSaveKey, saveData);
            }
        }

        public async UniTask LoadAsync()
        {
            if (!_playerService.TryGetPlayer(out uint playerId))
            {
                return;
            }
            
            if (_componentService.TryGetComponent(playerId, out IPathMoveComponent pathMoveComponent))
            {
                var saveData = await _saveService.LoadAsync(PlayerSaveKey, new PlayerSaveData
                {
                    NavigationQueue = new List<SaveVector3>(),
                    CurrentPosition = new SaveVector3(),
                    CurrentDirection = new SaveVector3(),
                    IsValid = false,
                });

                if (saveData.IsValid)
                {
                    pathMoveComponent.LoadFrom(saveData.NavigationQueue.ToVector3List(), saveData.CurrentPosition.ToVector3(), saveData.CurrentDirection.ToVector3());
                }
            }
        }
    }
}