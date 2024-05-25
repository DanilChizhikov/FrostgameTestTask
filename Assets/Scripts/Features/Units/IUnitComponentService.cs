namespace TestTask.Units
{
    public interface IUnitComponentService
    {
        void RegisterComponent(uint unitId, IComponentConfig config);
        void RemoveAllComponents(uint unitId);
    }
}