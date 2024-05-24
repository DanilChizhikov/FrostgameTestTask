using System.Collections.Generic;

namespace TestTask.Levels
{
    internal sealed class LevelRepository
    {
        private readonly Dictionary<string, int> _levelMap;
        private readonly List<string> _levels;
        
        public IReadOnlyList<string> Levels => _levels;

        public LevelRepository(LevelDatabase database)
        {
            _levelMap = new Dictionary<string, int>(database.Infos.Count);
            _levels = new List<string>(database.Infos.Count);
            for (int i = 0; i < database.Infos.Count; i++)
            {
                LevelInfo levelInfo = database.Infos[i];
                _levelMap.Add(levelInfo.Id, levelInfo.SceneIndex);
                _levels.Add(levelInfo.Id);
            }
        }

        public bool TryGetScene(string levelId, out int sceneIndex)
        {
            return _levelMap.TryGetValue(levelId, out sceneIndex);
        }
    }
}