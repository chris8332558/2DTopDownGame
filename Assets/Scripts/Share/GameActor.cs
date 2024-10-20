using UnityEngine;

public abstract class GameActor : MonoBehaviour
{
    // Basic variables for movement for any GameActor
    public Rigidbody2D body;
    public float moveSpeed;

    abstract public void Attack();

    virtual public void MoveTo(Vector2 aPos)
    { }

    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

}
