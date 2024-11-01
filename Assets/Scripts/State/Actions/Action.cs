using UnityEngine;

public abstract class Action : ScriptableObject 
{
    public string actionName;
    abstract public void Act(StateController aController);
    virtual public void DrawGizmo(StateController aController) { }
}
