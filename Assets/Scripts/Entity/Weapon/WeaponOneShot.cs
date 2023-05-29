using System.Pool;
using UnityEngine;

namespace Entity.Weapon
{
    public class WeaponOneShot : WeaponController
    {
        public override void Shoot(BulletPool bulletPool, Transform shotDir)
        {
            bulletPool.CreateBullet(shotDir);
        }
    }
}
