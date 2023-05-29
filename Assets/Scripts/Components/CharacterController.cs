using UnityEngine;

namespace Components
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movementComponent;
        [SerializeField] private InputComponent _inputComponent;
        [SerializeField] private AttackComponent _attackComponent;

        public void Update()
        {
            var direction = _inputComponent.GetMovementDirection();
            _movementComponent.Move(direction);
            var rotation = _inputComponent.GetRotation();
            _movementComponent.Rotate(rotation);
        
            var isAttack = _inputComponent.IsAttacking();
            var canAttack = _attackComponent.CanAttack;
            if(canAttack && isAttack)
            {
                _attackComponent.Attack();
            }
        
        }
        
    }
}