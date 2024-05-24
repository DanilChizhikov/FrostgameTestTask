using UnityEngine;

namespace TestTask.Inputs
{
    public interface IPlayerInputListener : IInputListener
    {
        void OnMove(Vector2 screenPoint);
    }
}