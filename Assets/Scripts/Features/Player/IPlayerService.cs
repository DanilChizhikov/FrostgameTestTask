using System;
using Cysharp.Threading.Tasks;

namespace TestTask.Player
{
    public interface IPlayerService
    {
        event Action OnPlayerCreated;
        event Action OnPlayerPreRemoved;
        
        string SelectedPlayer { get; }

        UniTask CreatePlayerAsync();
        bool TryGetPlayer(out uint playerId);
        UniTask RemovePlayerAsync();
    }
}