using Entity.Bullet;
using UnityEngine;

namespace System.Pool
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand = true;
        [SerializeField] private BulletMover _bulletPrefab;
    
        private Pool<BulletMover> _pool;

        private void Start()
        {
            _pool = new Pool<BulletMover>(_bulletPrefab, _poolCount, transform)
            {
                AutoExpand = _autoExpand
            };
        }
    
        public void CreateBullet(Transform shotDir)
        {
            var bullet = _pool.GetFreeElement();
            var o = bullet.gameObject;
            o.transform.position = shotDir.position;
            o.transform.rotation = shotDir.rotation;
        }
    
    }
}