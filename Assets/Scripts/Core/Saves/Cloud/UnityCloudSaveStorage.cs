using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.Core;

namespace TestTask.Saves
{
    internal sealed class UnityCloudSaveStorage : ISaveStorage
    {
        private readonly Dictionary<string, object> _saveMap;

        public UnityCloudSaveStorage()
        {
            _saveMap = new Dictionary<string, object>();
        }

        public async UniTask InitializeAsync()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Dictionary<string,Item> items = await CloudSaveService.Instance.Data.Player.LoadAllAsync();
            foreach (var item in items)
            {
                _saveMap[item.Value.Key] = item.Value.Value.GetAsString();
            }
        }

        public async UniTask WriteAsync(string key, string value)
        {
            _saveMap[key] = value;
            await CloudSaveService.Instance.Data.Player.SaveAsync(_saveMap);
        }

        public async UniTask<string> ReadAsync(string key, string defaultValue)
        {
            if (!_saveMap.TryGetValue(key, out object value))
            {
                value = defaultValue;
            }

            return value.ToString();
        }

        public async UniTask RemoveAsync(string key)
        {
            await CloudSaveService.Instance.Data.Player.DeleteAsync(key);
        }
    }
}