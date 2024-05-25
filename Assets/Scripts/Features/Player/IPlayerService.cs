using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TestTask.Player
{
    public interface IPlayerService
    {
        event Action OnPlayerCreated;
        event Action OnPlayerPreRemoved;
        
        string SelectedPlayer { get; }

        UniTask CreatePlayerAsync(Vector3 position, Quaternion quaternion);
        bool TryGetPlayer(out uint playerId);
        UniTask RemovePlayerAsync();
    }
}