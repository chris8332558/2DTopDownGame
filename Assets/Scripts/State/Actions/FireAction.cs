using UnityEngine;

[CreateAssetMenu(menuName = "Actions/FireAction")]
public class FireAction : Action 
{
    public float cooldown;
    [SerializeField] float cooldownTimer;

    public override void Act(StateController aController)
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > cooldown)
        {
            Fire(aController);
        }
    }

    private void Fire(StateController aController)
    {
        aController.controlledActor.Attack();
        cooldownTimer = 0;
	}
}
