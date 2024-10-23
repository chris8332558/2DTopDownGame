using UnityEngine;

[CreateAssetMenu(menuName = "Actions/PatrolAction")]
public class PatrolAction : Action 
{
    public override void Act(StateController aController)
    {
        Partol(aController);
    }

    private void Partol(StateController aController)
    {
	}
}
