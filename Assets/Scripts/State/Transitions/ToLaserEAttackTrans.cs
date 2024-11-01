using UnityEngine;

[CreateAssetMenu(menuName = "Transitions/ToLaserEAttackTrans")]
public class ToLaserEAttackTrans : Transition 
{
    public override bool Check(StateController aController)
    {
        // Debug.Log("Check if transition to " + nextState.name + " is possible");
        return aController.scanedTarget;
    }
}
