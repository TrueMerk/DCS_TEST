using System;
using Entity;
using UnityEngine;

namespace Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        private int _startHealth ;
        private EnemyPool _enemyPool;
        public event Action Dead;

        private void Start()
        {
            _enemyPool = ServiceLocator.Instance.GetService<EnemyPool>();
        }

        private void Awake()
        {
            _startHealth = _health;
        }
    
        private void OnEnable()
        {
            _health = _startHealth;
        }

        public void TookDamage()
        {
            if (_health >1)
                _health--;
            else
            {
                _health--;
                Dead?.Invoke();
                gameObject.SetActive(false);
                if (gameObject.GetComponent<EnemyShooter>())
                {
                    _enemyPool.EnemyList.Remove(this);
                }
                
            }
        }
    }
}
