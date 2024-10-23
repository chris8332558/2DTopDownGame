using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] int attackInterval;
    [SerializeField] int moveInterval;
    public Queue<ICommand> commandQueue = new();
    public List<IEnemy> controlTargets = new();

    private float emitAttackTimer;
    private float emitMoveTimer;

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

    public void AddControlTarget(IEnemy anEnemy)
    {
        controlTargets.Add(anEnemy);
	}


    public void EmitAttackCommand()
    {
        commandQueue.Enqueue(new AttackCommand());
	}

    public void EmitMoveCommand()
    {
        Vector2 randomPos = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
        commandQueue.Enqueue(new MoveCommand(randomPos));
	}
}
