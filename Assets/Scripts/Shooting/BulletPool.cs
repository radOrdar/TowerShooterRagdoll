using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class BulletPool
    {
        private Bullet bulletPrefab;
        private Queue<Bullet> queue = new();

        public BulletPool(Bullet bulletPrefab)
        {
            this.bulletPrefab = bulletPrefab;
        }

        public Bullet Get()
        {
            Bullet bullet;
            if (queue.Count == 0)
            {
                bullet = Object.Instantiate(bulletPrefab);
            } else
            {
                bullet = queue.Dequeue();
            }
            bullet.gameObject.SetActive(true);
            bullet.OriginFactory = this;
            return bullet;
        }

        public void Reclaim(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            queue.Enqueue(bullet);
        }
    }
}
