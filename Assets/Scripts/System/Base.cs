using Entity.Player;
using UnityEngine;

namespace System
{
    public class Base : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player!=null)
            {
                player.IsOnBase = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.GetComponent<Player>();
            if (player!=null)
            {
                player.IsOnBase = false;
            }
        }
    }
}
