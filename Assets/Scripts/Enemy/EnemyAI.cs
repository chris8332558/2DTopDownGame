using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float emitCommandInterval;
    public Transform attackTarget;
    private float emitTimer;
    public Queue<ICommand> CommandQueue;

    private void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        attackTarget = FindObjectOfType<Player>().transform;
    }

    public EnemyAI(Transform anAttackTarget)
    {
        attackTarget = anAttackTarget;
    }

    private void Update()
    {
        emitTimer += Time.deltaTime;
        if (emitTimer >= emitCommandInterval)
        {
            EmitCommand();
            emitTimer = 0;
        }
    }

    public void EmitCommand()
    {
        CommandQueue.Enqueue(new AttackCommand(attackTarget));
	}

}
