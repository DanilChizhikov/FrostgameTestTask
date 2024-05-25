namespace TestTask.Utils
{
    public interface IInstallable<in T>
    {
        void Install(T data);
    }
}