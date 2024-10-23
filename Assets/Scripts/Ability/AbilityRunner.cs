using UnityEngine;

public class AbilityRunner
{
    public IAbility currentAbility = null;

    public void SetAbility(IAbility anAbility)
    {
        currentAbility = anAbility;
        Debug.Log("Set Ability: " + currentAbility.AbilityName);
	}

    public void Use(Player player)
    {
        if (currentAbility == null)
        {
            Debug.Log("No Ability Set yet");
            return;
		}
        currentAbility.Use(player);
	}

    // DoSomething
}
