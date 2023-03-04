using UnityEngine;

namespace Services.Input
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        Vector3 mousePosition { get; }

        bool GetMouseButtonDown(int button);
        bool GetMouseButton(int button);
    }
}