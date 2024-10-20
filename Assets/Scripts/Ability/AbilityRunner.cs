public class AbilityRunner
{
    public IAbility currentAbility;

    public void SetAbility(IAbility anAbility)
    {
        currentAbility = anAbility;
	}

    public void Use(Player player)
    {
        currentAbility.Use(player);
	}

    // DoSomething
}
