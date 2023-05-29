using Components;
using Inputs;
using UnityEngine;

namespace Entity.Bullet
{
    public class BulletDamageDealer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerInput>();
            var health = other.GetComponent<Health>();
            if (player == null && health != null)
            {
                health.TookDamage();
            }
        }
    }
}
