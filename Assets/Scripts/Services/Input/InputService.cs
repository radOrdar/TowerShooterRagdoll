using UnityEngine;

namespace Services.Input
{
    class InputService : IInputService
    {
        public Vector2 Axis =>
            new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));

        public Vector3 mousePosition =>
            UnityEngine.Input.mousePosition;

        public bool GetMouseButtonDown(int button) =>
            UnityEngine.Input.GetMouseButtonDown(button);

        public bool GetMouseButton(int button) =>
            UnityEngine.Input.GetMouseButton(button);
    }
}