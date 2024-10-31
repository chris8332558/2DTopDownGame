using UnityEngine;

public class TriEnemy : GameActor, IEnemy
{
    [SerializeField] private string enemyName;
    [SerializeField] private float damage = 2f;
    private float exp = 10f;
    public string EnemyName { get => name; set => name = value; }
    public float Damage { get => damage; set => damage = value; }

    private Health health;
    private EnemyMovement enemyMovement;

    protected override void Awake()
    {
        base.Awake();
        health = GetComponent<Health>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void Initialize()
    {
        //Debug.Log("Initialize Enemy: " + EnemyName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Die();
		}
    }

    private void Update()
    {
        if (health.currentHealth <= 0)
        {
            Die();
		}
        enemyMovement.MoveTowardPlayer();
    }

    public void Die()
    {
        GamePlayEvents.EnemyDie.Invoke();
        GamePlayEvents.PlayerAddExp.Invoke(exp);
        Destroy(gameObject);
    }
}
