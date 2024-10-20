using UnityEngine;

public class AbilityA : IAbility
{
    public void Use(Player player)
    {
        player.playerAbility.UseAbilityA();
	}
}
