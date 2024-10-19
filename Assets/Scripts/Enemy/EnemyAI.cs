using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] int attackInterval;
    [SerializeField] int moveInterval;
    [SerializeField] private List<Transform> patrolPoints;
    public Transform attackTarget;
    public Queue<ICommand> CommandQueue;

    private float emitAttackTimer;
    private float emitMoveTimer;

    private void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        attackTarget = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        emitAttackTimer += Time.deltaTime;
        //emitMoveTimer += Time.deltaTime;
        if (emitAttackTimer >= attackInterval)
        {
            EmitAttackCommand();
            emitAttackTimer = 0;
        }
        //if (emitMoveTimer >= moveInterval)
        //{
        //    EmitMoveCommand();
        //    emitMoveTimer = 0;
		//}
    }

    private void EmitAttackCommand()
    {
        CommandQueue.Enqueue(new AttackCommand(attackTarget));
	}

    private void EmitMoveCommand()
    {
        CommandQueue.Enqueue(new MoveCommand(GetRandomPatrolPoint().position));
	}

    private Transform GetRandomPatrolPoint()
    {
        int idx = Random.Range(0, patrolPoints.Count);
        return patrolPoints[idx];
	}
}
