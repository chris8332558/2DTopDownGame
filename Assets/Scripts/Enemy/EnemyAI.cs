using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] int attackInterval;
    public Queue<ICommand> commandQueue = new();
    private IEnemy controlTarget;

    private float emitAttackTimer;

    private void Update()
    {
        emitAttackTimer += Time.deltaTime;
        if (emitAttackTimer >= attackInterval)
        {
            EmitAttackCommand();
            emitAttackTimer = 0;
        }
    }

    public void SetControlTarger(IEnemy anEnemy)
    {
        controlTarget = anEnemy;
	}

    public void EmitAttackCommand()
    {
        commandQueue.Enqueue(new AttackCommand());
	}
}
