using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deatVirtualCamera;
    [SerializeField] Transform weaponCamera;

    int currentHealth;
    int gameOverVirtualCameraPriorty = 20;

    void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount) // amount of damage to take
    {
        currentHealth -= amount;
        Debug.Log(amount + " damage taken");

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deatVirtualCamera.Priority = gameOverVirtualCameraPriorty;
            Destroy(this.gameObject);
        }
    }
}
