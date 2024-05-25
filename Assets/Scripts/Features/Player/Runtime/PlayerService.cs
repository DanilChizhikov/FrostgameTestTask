using System;
using Cysharp.Threading.Tasks;

namespace TestTask.Player
{
    internal sealed class PlayerService : IPlayerService
    {
        public event Action OnPlayerCreated;
        public event Action OnPlayerPreRemoved;
        public string SelectedPlayer { get; }
        public UniTask CreatePlayerAsync()
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayer(out uint playerId)
        {
            throw new NotImplementedException();
        }

        public UniTask RemovePlayerAsync()
        {
            throw new NotImplementedException();
        }
    }
}