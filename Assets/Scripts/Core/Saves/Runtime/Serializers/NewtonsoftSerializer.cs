using Newtonsoft.Json;
using UnityEngine;

namespace TestTask.Saves
{
    [CreateAssetMenu(fileName = nameof(NewtonsoftSerializer), menuName = "Data/Configs/Save/" + nameof(NewtonsoftSerializer))]
    internal sealed class NewtonsoftSerializer : Serializer
    {
        public override string Serialize(object value) => JsonConvert.SerializeObject(value);

        public override T DeSerialize<T>(string args) => JsonConvert.DeserializeObject<T>(args);
    }
}