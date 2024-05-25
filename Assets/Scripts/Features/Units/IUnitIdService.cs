namespace TestTask.Units
{
    public interface IUnitIdService
    {
        uint GetNextId();
        
        bool TryGetUnit(uint id, out IUnitEntity unit);
        void Add(IUnitEntity entity);
        void Remove(IUnitEntity entity);
    }
}