using Shooting;
using UnityEngine;

namespace Hero
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private Gun gun;
        public void UpdateBodyAndGunRotation(Vector3 target)
        {
            Vector3 playerLookPoint = target;
            playerLookPoint.y = transform.position.y;
            Quaternion bodyTargetRotation = Quaternion.LookRotation(playerLookPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, bodyTargetRotation, Time.deltaTime * 10);

            Quaternion gunTargetRotation = Quaternion.LookRotation(target - gun.transform.position);
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, gunTargetRotation, Time.deltaTime * 30);
            // gun.transform.LookAt(target);
        }
        
        public void GunSetActive(bool isActive)
        {
            gun.SetActive(isActive);
        }

        //animation Event
        public void Shoot()
        {
            gun.Shoot();
        }
    }
}