using UnityEngine;

public class AttackCommand : ICommand
{
    private Transform target;

    public AttackCommand(Transform aTarget) 
    {
        target = aTarget;
    }

    public void Execute(GameActor aActor)
    {
        aActor.Attack(target);
	}
}
