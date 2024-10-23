public class FireAbility : IAbility
{
    private string abilityName;
    public string AbilityName { get => abilityName; set => abilityName = value; }

    public void Use(Player player)
    {
        player.playerAbility.LaunchFireball();
	}
}
