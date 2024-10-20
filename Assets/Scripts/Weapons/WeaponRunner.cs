public class WeaponRunner
{
    public IWeapon currentWeapon;

    public void SetWeapon(IWeapon aWeapon)
    {
        currentWeapon = aWeapon;
	}

    public void Use(GameActor anActor)
    {
        currentWeapon.Use(anActor);
	}

    // DoSomething
}
