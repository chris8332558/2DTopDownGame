using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] int attackInterval;
    [SerializeField] int moveInterval;
    public Transform attackTarget;
    public Vector2 movePoint1;
    public Vector2 movePoint2;
    public Queue<ICommand> CommandQueue;

    private float emitAttackTimer;
    private float emitMoveTimer;

    private void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        attackTarget = FindObjectOfType<Player>().transform;
        movePoint1 = (Vector2)transform.position + Vector2.right * 3;
    }

    public EnemyAI(Transform anAttackTarget)
    {
        attackTarget = anAttackTarget;
    }

    private void Update()
    {
        emitAttackTimer += Time.deltaTime;
        emitMoveTimer += Time.deltaTime;
        if (emitAttackTimer >= attackInterval)
        {
            EmitAttackCommand();
            emitAttackTimer = 0;
        }
        if (emitMoveTimer >= moveInterval)
        {
            EmitMoveCommand();
            emitMoveTimer = 0;
		}
    }

    private void EmitAttackCommand()
    {
        CommandQueue.Enqueue(new AttackCommand(attackTarget));
	}

    private void EmitMoveCommand()
    {
        CommandQueue.Enqueue(new MoveCommand(movePoint1));
	}
}
