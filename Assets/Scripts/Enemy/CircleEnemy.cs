using UnityEngine;

public class CircleEnemy : GameActor, IEnemy 
{
    [SerializeField] private string enemyName;
    [SerializeField] private float damage;
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public float Damage { get => damage; set => damage = value; }

    [SerializeField] ObjectPool bulletRedPool;
    [SerializeField] Transform firePoint;
    [SerializeField] private float fireForce;
    private EnemyAI ai;

    protected override void Awake()
    {
        base.Awake();
        ai = GetComponent<EnemyAI>();
        bulletRedPool = GameObject.Find("BulletRedPool").GetComponent<ObjectPool>(); ;
    }

    private void FixedUpdate()
    {
        TurnToTarget();
    }

    private void Update()
    {
        ExecuteCommand();
    }

    public void Initialize()
    {
        Debug.Log(EnemyName + "::Initialize()");
    }

    public override void Attack(Transform aTarget)
    {
        Debug.Log(EnemyName + "::Attack()");
        PooledObject aBullet = bulletRedPool.GetPooledObject();
        aBullet.transform.position = firePoint.position;
        aBullet.transform.rotation = firePoint.rotation;
        aBullet.gameObject.SetActive(true);
        aBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    private void ExecuteCommand()
    { 
        if (ai.CommandQueue.Count != 0)
        {
            ICommand aCommand = ai.CommandQueue.Dequeue();
            if (aCommand != null)
                aCommand.Execute(this);
        }
	}

    private void TurnToTarget()
    { 
        Vector2 lookDir = (Vector2)ai.attackTarget.position - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
	}
}
