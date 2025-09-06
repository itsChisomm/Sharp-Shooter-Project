using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject robotExplosionVFX;

    int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount) // amount of damage to take
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        }
    }
}

