using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public AbilityRunner abilityRunner = new();
    public AbilityA abilityA = new(); // can change to use scriptableObject
    public AbilityB abilityB = new();

    private void Start()
    {
        abilityRunner.SetAbility(abilityA);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilityRunner.SetAbility(abilityA);
            abilityRunner.Use(this.GetComponent<Player>());
		}
        if (Input.GetKeyDown(KeyCode.E))
        {
            abilityRunner.SetAbility(abilityB);
            abilityRunner.Use(this.GetComponent<Player>());
		}
    }

    public void UseAbilityA()
    { 
        Debug.Log("Player.UseAbilityA()");
	}

    public void UseAbilityB()
    { 
        Debug.Log("Player.UseAbilityB()");
	}
}
