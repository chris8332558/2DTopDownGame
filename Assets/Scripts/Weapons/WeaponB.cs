using UnityEngine;

public class WeaponB : IWeapon
{
    public void Use(GameActor anActor)
    {
        Debug.Log("WeaponB::Use()");
	}
}
