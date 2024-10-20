using UnityEngine;
using System;
using System.Collections;

public class CircleEnemy : GameActor, IEnemy 
{
    [SerializeField] private string enemyName;
    [SerializeField] private float damage;
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public float Damage { get => damage; set => damage = value; }

    [SerializeField] ObjectPool bulletRedPool;
    [SerializeField] Transform firePoint;
    [SerializeField] private float fireForce;
    [SerializeField] private Transform[] partolPoints;
    [SerializeField] private Player player;

    [SerializeField] private EnemyAI ai;

    private float exp = 30f;
    private Health health;

    protected override void Awake()
    {
        base.Awake();
        ai = GetComponent<EnemyAI>();
        health = GetComponent<Health>();
        player = FindObjectOfType<Player>();
        bulletRedPool = GameObject.Find("BulletRedPool").GetComponent<ObjectPool>(); ;
        moveSpeed = 3f;
    }

    private void Start()
    {
        ai.AddControlTarget(this);
    }

    private void FixedUpdate()
    {
        TurnToPlayer();
    }

    private void Update()
    {
        ExecuteCommand();
        if (health.currentHealth <= 0)
        {
            Die();
		}
    }

    public void Initialize()
    {
        // Other logic when initialize this
        Debug.Log(EnemyName + "::Initialize()");
    }

    public override void Attack()
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
        if (ai.commandQueue.Count != 0)
        {
            ICommand aCommand = ai.commandQueue.Dequeue();
            if (aCommand != null)
                aCommand.Execute(this);
        }
	}

    private void TurnToPlayer()
    { 
        Vector2 lookDir = (Vector2)player.transform.position - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
	}

    public override void MoveTo(Vector2 aPos)
    {
        Vector2 target = transform.position;
        StartCoroutine(MoveEnumerator(target + aPos));
    }

    private IEnumerator MoveEnumerator(Vector2 aPos)
    {
        float t = 0;
        Vector2 start = transform.position;
        while (t <= 1)
        {
            t += Time.fixedDeltaTime / moveSpeed;
            body.MovePosition(Vector2.Lerp(start, aPos, t));
            yield return null;
		}
	} 

    public void Die()
    {
        GamePlayEvents.EnemyDie.Invoke();
        GamePlayEvents.PlayerAddExp.Invoke(exp);
        Destroy(gameObject);
	}
}
