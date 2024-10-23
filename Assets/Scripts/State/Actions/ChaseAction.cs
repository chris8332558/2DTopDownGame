using UnityEngine;

[CreateAssetMenu(menuName = "Actions/ChaseAction")]
public class ChaseAction : Action 
{
    public override void Act(StateController aController)
    {
        Chase(aController);
	}

    private void Chase(StateController aController)
    {
        // Debug.Log(name);
	}
}
