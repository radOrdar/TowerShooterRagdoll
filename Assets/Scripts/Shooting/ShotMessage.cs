using UnityEngine;

namespace Shooting
{
    public struct ShotMessage
    {
        public float damage;
        public float speed;
        public Vector3 direction;
        public Vector3 spawnPoint;
        public Vector3 impactPoint;
        public ShotTarget shotTarget;
    }
}