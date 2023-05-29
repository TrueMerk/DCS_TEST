using System;
using Components;
using UnityEngine;

namespace Entity.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public bool IsDead { get; private set; } = false;
        public bool IsOnBase { get; set; } = true;

        public event Action Death;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService(this);
        }

        private void Start()
        {
            _health.Dead += Dead;
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.DeregisterService<Player>();
        }

        private void Dead()
        {
            Death?.Invoke();
            IsDead = true;
        }
    }
}
