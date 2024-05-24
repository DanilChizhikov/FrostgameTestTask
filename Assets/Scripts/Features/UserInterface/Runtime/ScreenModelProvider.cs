using System;
using System.Collections.Generic;

namespace TestTask.UserInterface
{
    internal sealed class ScreenModelProvider
    {
        private readonly List<ScreenModel> _models;
        private readonly Dictionary<Type, int> _screenMap;

        public IReadOnlyList<ScreenModel> Models => _models;
        
        public ScreenModelProvider(IEnumerable<ScreenModel> models)
        {
            _models = new List<ScreenModel>(models);
            _screenMap = new Dictionary<Type, int>(_models.Count);
            for (int i = 0; i < _models.Count; i++)
            {
                _screenMap.Add(_models[i].GetType(), i);
            }
        }
        
        public bool TryGetScreenModel(Type type, out ScreenModel model)
        {
            bool hasModel = _screenMap.TryGetValue(type, out int index);
            if (!hasModel)
            {
                index = GetModelIndex(type);
                hasModel = index >= 0;
                if (hasModel)
                {
                    model = _models[index];
                }
            }
            
            model = hasModel ? _models[index] : null;
            return hasModel;
        }

        private int GetModelIndex(Type type)
        {
            int index = -1;
            for (int i = 0; i < _models.Count; i++)
            {
                ScreenModel model = _models[i];
                if (model.GetType().IsAssignableFrom(type))
                {
                    index = i;
                    break;
                }
            }
            
            return index;
        }
    }
}