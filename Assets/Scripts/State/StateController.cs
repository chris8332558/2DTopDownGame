using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private State currentState;
    public State CurrentState { get => currentState; set => currentState = value; }

    public GameActor controlledActor;
    public Transform eye;
    public LayerMask scanLayer;
    public Transform[] patrolPoints;

    public float scanRange;
    public bool isActive;
    public bool scanedTarget;

    private void Awake()
    {
        controlledActor = GetComponent<GameActor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            isActive = !isActive;
		}
        if (isActive)
        {
            currentState.ExecuteActions(this);
            currentState.TryTransitions(this);
        }
    }

    public void TransitionToState(State aState)
    {
        currentState = aState;
    }

    public void Setup(bool anActiveState, State anInitialState)
    {
        // Game Manager will call this function
        isActive = anActiveState;
        currentState = anInitialState; 
	}

    private void OnDrawGizmos()
    {
        if (isActive)
        {
            Gizmos.color = currentState.gizmoColor;
            currentState.DrawActionGizmo(this);
        }
    }
}
