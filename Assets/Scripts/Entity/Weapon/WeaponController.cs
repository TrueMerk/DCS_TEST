using System.Pool;
using UnityEngine;

namespace Entity.Weapon
{
    public abstract class WeaponController : MonoBehaviour
    {
        public abstract void Shoot(BulletPool bulletPool,Transform shotDir);
    }
}