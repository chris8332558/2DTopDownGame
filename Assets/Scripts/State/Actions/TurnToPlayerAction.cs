using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TurnToPlayerAction")]
public class TurnToPlayerAction: Action 
{
    public override void Act(StateController aController)
    {
        TurnToPlayer(aController);
    }

    private void TurnToPlayer(StateController aController)
    {
        Vector2 lookDir = aController.player.transform.position - aController.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        aController.controlledActor.body.rotation = angle;
	}
}
