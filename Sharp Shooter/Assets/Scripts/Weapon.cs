using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";

    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        
        if (!starterAssetsInputs.shoot) return;

            muzzleFlash.Play();
            animator.Play(SHOOT_STRING, 0, 0f);
            starterAssetsInputs.ShootInput(false);

        RaycastHit hit; // variable to store information about what was hit

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(damageAmount);

        }
    }
 }

