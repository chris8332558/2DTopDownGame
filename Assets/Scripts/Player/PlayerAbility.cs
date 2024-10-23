using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public AbilityRunner abilityRunner = new();
    public FireAbility fireAbility = new(); // can change to use scriptableObject
    public IceAbility iceAbility = new();
    public LaserAbility laserAbility = new();
    public ShieldAbility shieldAbility = new();

    private Player player;
    private PlayerInput playerInput;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();

        SetupAbilityNames();
    }

    private void Update()
    {
        HandleAbilitySetting();
        if (Input.GetKeyDown(playerInput.AbilityUseKey))
        {
            abilityRunner.Use(player);
		}
    }

    public void LaunchFireball()
    { 
        Debug.Log("Player.LaunchFireBall");
	}

    public void LaunchIceBall()
    { 
        Debug.Log("Player.LaunchIceBall");
	}
     
    public void LaunchLaser()
    { 
        Debug.Log("Player.LaunchLaser");
	}

    public void LaunchShield()
    { 
        Debug.Log("Player.LaunchShield");
	}

    private void HandleAbilitySetting()
    { 
        if (Input.GetKeyDown(playerInput.Ability1Key))
        {
            abilityRunner.SetAbility(fireAbility);
		}
        else if (Input.GetKeyDown(playerInput.Ability2Key))
        {
            abilityRunner.SetAbility(iceAbility);
		}
        else if (Input.GetKeyDown(playerInput.Ability3Key))
        {
            abilityRunner.SetAbility(laserAbility);
		}
        else if (Input.GetKeyDown(playerInput.Ability4Key))
        {
            abilityRunner.SetAbility(shieldAbility);
		}
	}
    private void SetupAbilityNames()
    {
        fireAbility.AbilityName = "Player Fireball";
        iceAbility.AbilityName = "Player Iceball";
        laserAbility.AbilityName = "Player Laser";
        shieldAbility.AbilityName = "Player Shield";
	}
}
