using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Player
{
    [CreateAssetMenu(fileName = "PlayerDatabase", menuName = "Data/Player/" + nameof(PlayerDatabase), order = 0)]
    internal sealed class PlayerDatabase : ScriptableObject
    {
        [SerializeField] private PlayerInfo[] _infos = Array.Empty<PlayerInfo>();
        
        public IReadOnlyList<PlayerInfo> Infos => _infos;
    }
}