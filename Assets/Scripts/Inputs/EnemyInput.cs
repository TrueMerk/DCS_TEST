using System;
using Components;
using Entity.Player;
using UnityEngine;

namespace Inputs
{
    public class EnemyInput : InputComponent
    {
        [SerializeField] private float _attackDistance = 1;
        private Player _player;
        
        private void OnEnable()
        {
            _player = ServiceLocator.Instance.GetService<Player>();
        }
        
        private Vector3 Difference()
        {
            var playerPosition = _player.transform.position;
            return playerPosition - transform.position;
        }
    
        public override Vector3 GetMovementDirection()
        {
            if (Difference().magnitude <= _attackDistance || _player.IsDead)
            {
                return Vector3.zero;
            }
            return Difference();
        }

        public override Quaternion GetRotation()
        {
            // var direction = Difference();
            //
            // if (!(direction.magnitude > 1)) return transform.rotation;
            //
            // direction.y = 0f;
            // var targetRotation = Quaternion.LookRotation(direction);
            //
            // return targetRotation;
            return transform.rotation;
        }

        public override bool IsAttacking()
        {
            return Difference().magnitude <= _attackDistance;
        }

        
    }
}
