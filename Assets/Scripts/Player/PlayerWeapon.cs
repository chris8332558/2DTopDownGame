using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private WeaponRunner weaponRunner = new();
    private WeaponA weaponA = new();
    private WeaponB weaponB = new();

    private void Start()
    {
        weaponRunner.SetWeapon(weaponA);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponRunner.SetWeapon(weaponA);
		}
        if (Input.GetKeyDown(KeyCode.E))
        {
            weaponRunner.SetWeapon(weaponB);
		}
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponRunner.Use(this.GetComponent<Player>());
		}
    }
}
