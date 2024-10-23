public class LaserAbility : IAbility 
{
    private string abilityName;
    public string AbilityName { get => abilityName; set => abilityName = value; }

    public void Use(Player aPlayer)
    {
        aPlayer.playerAbility.LaunchLaser();    
	}
}
