using System;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Collider))]
    public class ShotTarget : MonoBehaviour
    {
        public Action<ShotMessage> OnShot;

        public void TakeShot(ShotMessage shotMessage)
        {
            Debug.Log("TakeShot");
            shotMessage.shotTarget = this;
            OnShot(shotMessage);
        }
    }
}