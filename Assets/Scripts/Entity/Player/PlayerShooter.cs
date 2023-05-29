using System;
using System.Collections;
using System.Pool;
using Components;
using Entity.Weapon;
using UnityEngine;

namespace Entity.Player
{
    public class PlayerShooter : AttackComponent
    {
        [SerializeField] private BulletPool _bullet;
        [SerializeField] public Transform _shotDir;
        [SerializeField] private float _shootRate;
        [SerializeField] private WeaponSwitcher _switcher;
        private GameObject _playerPos;
        private bool _isReload;
        private EnemyPool _enemyPool;
        private Entity.Player.Player _player;
        private bool _enemyExist;
        private WeaponController _weapon;

        public override bool CanAttack => !_isReload ;
    
        private void Start()
        {
            _player = ServiceLocator.Instance.GetService<Entity.Player.Player>();
        }
    
        private void Shoot()
        {
            _switcher.GetCurrentWeapon().Shoot(_bullet,_shotDir);
            StartCoroutine(Reload());
        }

        private IEnumerator Reload()
        {
            _isReload = true;
            yield return new WaitForSeconds(_shootRate);
            _isReload = false;
        }
        
        public override void Attack()
        {
            if (!_isReload)
            {
                Shoot();
            }
        }
    }
}
