public class Player : GameActor 
{
    private PlayerLevel playerLevel;
    private PlayerAttack playerAttack;
    public PlayerAbility playerAbility;

    private bool reachLevel2;

    protected override void Awake()
    {
        base.Awake();
        playerLevel = GetComponent<PlayerLevel>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAbility = GetComponent<PlayerAbility>();
    }

    private void Update()
    {
        if (playerLevel.CurrentLevel == 2 && !reachLevel2)
        {
            playerAttack.UpdateBulletPool();
            reachLevel2 = true;
		}
    }
}
