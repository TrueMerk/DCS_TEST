using UnityEngine;

namespace Entity.Weapon
{
    public class WeaponSwitcher : MonoBehaviour
    {
        public WeaponController[] weapons;
        private int currentWeaponIndex = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchWeapon();
            }
        }

        private void SwitchWeapon()
        {
            weapons[currentWeaponIndex].gameObject.SetActive(false);

            currentWeaponIndex++;
            if (currentWeaponIndex >= weapons.Length)
            {
                currentWeaponIndex = 0;
            }

            weapons[currentWeaponIndex].gameObject.SetActive(true);
        }

        public WeaponController GetCurrentWeapon()
        {
            return weapons[currentWeaponIndex];
        }
    }
}
