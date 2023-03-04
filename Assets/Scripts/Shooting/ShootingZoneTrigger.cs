using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Collider))]
    public class ShootingZoneTrigger : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}