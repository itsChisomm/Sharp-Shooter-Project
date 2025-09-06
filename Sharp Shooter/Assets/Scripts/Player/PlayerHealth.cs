using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount) // amount of damage to take
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
