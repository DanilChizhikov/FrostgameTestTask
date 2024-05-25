using UnityEngine;

namespace TestTask.Units
{
    internal abstract class NavigationConfig : ComponentConfig, INavigationConfig
    {
        [SerializeField, Min(0f)] private float _minSearchDistance = 0f;

        public float MinSearchDistance => _minSearchDistance;
    }
}