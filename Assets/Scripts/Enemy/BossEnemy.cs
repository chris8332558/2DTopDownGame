using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : GameActor, IEnemy
{
    [SerializeField] private string enemyName;
    [SerializeField] private float damage;
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public float Damage { get => damage; set => damage = value; }

    [SerializeField] ObjectPool bulletRedPool;
    [SerializeField] Health health;
    [SerializeField] Transform firePoint;
    [SerializeField] private float fireForce;

    private float exp = 80f;

    
    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
        bulletRedPool = GameObject.Find("BulletRedPool").GetComponent<ObjectPool>();
        moveSpeed = 3f;
    }

    public void Initialize()
    { 
        // Other logic when initialize this
        // Debug.Log(EnemyName + "::Initialize()");
	}

    private void Update()
    {
        if (health.currentHealth <= 0)
        {
            Die();
		}
    }

    public override void Attack()
    {
        // Debug.Log(EnemyName + "::Attack()");
        PooledObject aBullet = bulletRedPool.GetPooledObject();
        aBullet.transform.position = firePoint.position;
        aBullet.transform.rotation = firePoint.rotation;
        aBullet.gameObject.SetActive(true);
        aBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void Die()
    { 
        GamePlayEvents.EnemyDie.Invoke();
        GamePlayEvents.PlayerAddExp.Invoke(exp);
        Destroy(gameObject);
	}
}
