using UnityEngine;

public abstract class Transition : ScriptableObject
{
    public State nextState;

    public abstract bool Check(StateController aController);
}
