using System;
using UnityEngine;

namespace Services.Input
{
    class InputService : IInputService
    {
        public Vector2 Axis => throw new NotImplementedException();

        public bool IsAttackButtonUp()
        {
            throw new NotImplementedException();
        }
    }
}