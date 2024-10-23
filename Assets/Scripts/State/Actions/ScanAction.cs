using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Actions/ScanAction")]
public class ScanAction : Action 
{
    public override void Act(StateController aController)
    {
        Scan(aController);
	}

    private void Scan(StateController aController)
    {
        Transform theEye = aController.eye;
        RaycastHit2D hit = Physics2D.Raycast(theEye.position, theEye.up, aController.scanRange, aController.scanLayer);
        Debug.DrawRay(theEye.position, theEye.up * aController.scanRange);
        aController.scanedTarget = hit;

        // TODO: add rotation
        // Debug.Log(name);
	}
}
