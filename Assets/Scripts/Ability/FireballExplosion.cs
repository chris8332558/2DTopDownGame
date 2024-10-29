using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] float damage;
    [SerializeField] float damageInterval;
    [SerializeField] float damageTimer;
    [SerializeField] string targetTag;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && damageTimer >= damageInterval)
        {
		    collision.GetComponent<Health>().TakeDamage(damage);
            damageTimer = 0;
		}
    }
}
