using Components;
using UnityEngine;

namespace Inputs
{
    public class PlayerInput : InputComponent
    {
        public override Vector3 GetMovementDirection()
        {
            return Input.GetAxis("Vertical") * Vector3.forward + Input.GetAxis("Horizontal")*Vector3.right;
        }

        public override Quaternion GetRotation()
        {
            var mousePositionScreen = Input.mousePosition;
            
            var plane = new Plane(Vector3.up, transform.position);
            
            if (Camera.main == null) return transform.rotation;
            var ray = Camera.main.ScreenPointToRay(mousePositionScreen);

            if (!plane.Raycast(ray, out var distance)) return transform.rotation;
            var mousePositionWorld = ray.GetPoint(distance);
                
            var direction = mousePositionWorld - transform.position;
                
            direction.y = 0f;

            if (direction == Vector3.zero) return transform.rotation;
            var targetRotation = Quaternion.LookRotation(direction);
            return targetRotation;
        }
        
        public override bool IsAttacking()
        {
            return Input.GetButtonDown("Fire1");
        }
    }
}