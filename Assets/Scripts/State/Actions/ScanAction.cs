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
        //RaycastHit2D hit = Physics2D.Raycast(theEye.position, theEye.up, aController.scanRange, aController.scanLayer);
        //RaycastHit2D hit = Physics2D.CapsuleCast(theEye.position, new Vector2(2, 3), CapsuleDirection2D.Vertical, 0, 
        //	                                     theEye.up, aController.scanRange, aController.scanLayer);
        RaycastHit2D hit = Physics2D.BoxCast(theEye.position, new Vector2(1, 1), 0, theEye.up, 
			                                 aController.scanRange, aController.scanLayer); ;
        aController.scanedTarget = hit;
        // Debug.Log(name);
    }

    public override void DrawGizmo(StateController aController)
    { 
        Transform theEye = aController.eye;
        //Gizmos.DrawRay(theEye.position, theEye.up * aController.scanRange);
        Gizmos.DrawWireCube(theEye.position + Vector3.up * (aController.scanRange / 2), 
			                Vector3.right + Vector3.up * aController.scanRange);
	}
}
