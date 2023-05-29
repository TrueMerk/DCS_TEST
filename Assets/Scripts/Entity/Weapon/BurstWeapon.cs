using System.Collections;
using System.Pool;
using UnityEngine;

namespace Entity.Weapon
{
    public class BurstWeapon : WeaponController
    {
        [SerializeField] private int _bulletCount;
        [SerializeField] private double _fireRate = 0.1;
        
        public override void Shoot(BulletPool bulletPool, Transform shotDir)
        {
            StartCoroutine(Burst(bulletPool,shotDir));
        }

        private IEnumerator Burst(BulletPool bulletPool, Transform shotDir)
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                bulletPool.CreateBullet(shotDir);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}