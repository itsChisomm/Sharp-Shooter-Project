using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        //pickup weapon when player enters trigger
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>(); // get the ActiveWeapon component from the player
            if (activeWeapon != null) // ensure the player has an ActiveWeapon component
            {
                activeWeapon.SwitchWeapon(weaponSO);
                Destroy(this.gameObject); // destroy the pickup object
            } // remove if statement if you want to allow multiple pickups
        }
    }
}
