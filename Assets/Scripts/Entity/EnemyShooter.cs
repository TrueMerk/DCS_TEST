using System;
using System.Collections;
using Components;
using UnityEngine;

namespace Entity
{
    public class EnemyShooter : AttackComponent
    {
        [SerializeField] private float _attackRate;
        private Health _playerHealth;
        private bool _isReload;
        public override bool CanAttack => !_isReload;
        private void Start()
        {
            _playerHealth = ServiceLocator.Instance.GetService<Entity.Player.Player>().GetComponent<Health>();
        }
        
        private void Shoot()
        {
            _playerHealth.TookDamage();
            StartCoroutine(Reload());
        }
        
        private IEnumerator Reload()
        {
            _isReload = true;
            yield return new WaitForSeconds(_attackRate);
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
