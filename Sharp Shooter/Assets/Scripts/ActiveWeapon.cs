using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;

    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot = 0f;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;
        
        if (!starterAssetsInputs.shoot) return; 

        if (timeSinceLastShot >= weaponSO.FireRate) // can shoot
        { 
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }
        if (!weaponSO.IsAutomatic) 
        {
            starterAssetsInputs.ShootInput(false); // reset shoot input for semi-automatic weapons
        }
    }

    void HandleZoom()
    {
        // Implement zoom functionality if needed
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming");
        }
        else
        {
            Debug.Log("Not Zooming");
        }       
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }
}
