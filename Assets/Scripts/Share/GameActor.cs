using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    protected Rigidbody2D body;

    abstract public void Attack(Transform aTarget);

    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
}
