using System.Collections.Generic;
using TestTask.Utils;

namespace TestTask.Units
{
    internal abstract class UnitController : IUnitController
    {
        private readonly ObjectTypeMap<IUnitComponent> _componentMap;

        public UnitController(IEnumerable<IUnitComponent> components)
        {
            _componentMap = new ObjectTypeMap<IUnitComponent>(components);
        }
        
        public TComponent GetComponent<TComponent>() where TComponent : IUnitComponent
        {
            return (TComponent)_componentMap.GetItem(typeof(TComponent));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : IUnitComponent
        {
            component = default;
            bool hasComponent = _componentMap.TryGetItem(typeof(TComponent), out IUnitComponent cachedComponent);
            if (hasComponent)
            {
                component = (TComponent)cachedComponent;
            }

            return hasComponent;
        }
    }

    internal abstract class UnitController<TModel, TView> : UnitController
        where TModel : Unit
        where TView : UnitView
    {
        protected TModel Model { get; }
        protected TView View { get; }
        
        public UnitController(TModel model, TView view, IEnumerable<IUnitComponent> components) : base(components)
        {
            Model = model;
            View = view;
        }
    }
}