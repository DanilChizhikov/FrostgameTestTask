using Cysharp.Threading.Tasks;

namespace TestTask.Saves
{
    internal sealed class SaveService : ISaveService
    {
        private readonly ISerializer _serializer;
        private readonly ISaveStorage _saveStorage;

        public SaveService(ISaveStorage saveStorage, ISerializer serializer)
        {
            _saveStorage = saveStorage;
            _serializer = serializer;
        }

        public async UniTask SaveAsync<T>(string key, T value)
        {
            string serializedValue = _serializer.Serialize(value);
            await _saveStorage.WriteAsync(key, serializedValue);
        }

        public async UniTask<T> LoadAsync<T>(string key, T defaultValue)
        {
            string serializedValue = await _saveStorage.ReadAsync(key, _serializer.Serialize(defaultValue));
            return _serializer.DeSerialize<T>(serializedValue);
        }
    }
}