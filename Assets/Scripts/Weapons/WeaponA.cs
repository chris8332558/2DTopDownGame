using UnityEngine;

public class WeaponA : IWeapon
{
    public void Use(GameActor anActor)
    {
        Debug.Log("WeaponA::Use()");
	}
}
