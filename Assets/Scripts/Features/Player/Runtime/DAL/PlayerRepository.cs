using System.Collections.Generic;

namespace TestTask.Player
{
    internal sealed class PlayerRepository
    {
        private readonly Dictionary<string, string> _playerMap;

        public PlayerRepository(PlayerDatabase database)
        {
            _playerMap = new Dictionary<string, string>(database.Infos.Count);
            for (int i = 0; i < database.Infos.Count; i++)
            {
                PlayerInfo playerInfo = database.Infos[i];
                _playerMap.Add(playerInfo.Id, playerInfo.UnitId);
            }
        }
        
        public bool TryGetPlayer(string id, out string unitId)
        {
            return _playerMap.TryGetValue(id, out unitId);
        }
    }
}