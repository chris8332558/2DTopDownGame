using UnityEngine;

public class AbilityB : IAbility
{
    public void Use(Player player)
    {
        player.playerAbility.UseAbilityB();
	}
}
