// Strategy pattern
public interface IAbility
{
    public string AbilityName { get; set; }
    public void Use(Player player);
}
