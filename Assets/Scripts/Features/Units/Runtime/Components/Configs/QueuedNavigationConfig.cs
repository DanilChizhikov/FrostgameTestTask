using UnityEngine;

namespace TestTask.Units
{
    [CreateAssetMenu(menuName = "Configs/Units/Components/" + nameof(QueuedNavigationConfig), fileName = nameof(QueuedNavigationConfig))]
    internal sealed class QueuedNavigationConfig : NavigationConfig, IQueuedNavigationConfig
    {
        [SerializeField, Min(1)] private int _queueSize = 1;
        
        public int QueueSize => _queueSize;
    }
}