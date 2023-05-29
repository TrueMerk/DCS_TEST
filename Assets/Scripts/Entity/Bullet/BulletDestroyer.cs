using Inputs;
using UnityEngine;

namespace Entity.Bullet
{
    public class BulletDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerInput>();
            if (player == null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
