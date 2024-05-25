namespace TestTask.Saves
{
    public interface ISerializer
    {
        string Serialize(object value);
        T DeSerialize<T>(string stringValue);
    }
}