using UnityEngine;

[CreateAssetMenu(menuName = "Actions/SpinAction")]
public class SpinAction : Action 
{
    public override void Act(StateController aController)
    {
        Spin(aController);
    }

    private void Spin(StateController aController)
    {
        aController.transform.Rotate(Vector3.back, aController.rotateSpeed * Time.deltaTime);
	}
}
