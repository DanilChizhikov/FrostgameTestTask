namespace TestTask.Units
{
    public interface IUnitController
    {
        TComponent GetComponent<TComponent>() where TComponent : IUnitComponent;
        bool TryGetComponent<TComponent>(out TComponent component) where TComponent : IUnitComponent;
    }
}