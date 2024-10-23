using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    // Note this is not an abstract, every state is looping through the actions, and we assign
    // different actions to different state
    public Action[] actions;
    public Transition[] transitions;
    public Color gizmoColor;

    public void ExecuteActions(StateController aController)
    { 
	    foreach(Action anAction in actions)
        {
            anAction.Act(aController);
		}
	}

    public void TryTransitions(StateController aController)
    { 
	    foreach(Transition aTransition in transitions)
        {
            bool result = aTransition.Check(aController);
            if (result)
            {
                aController.TransitionToState(aTransition.nextState);
                Debug.Log("Transition to: " + aTransition.nextState.name);
                return;
			}
		}
	}
}
