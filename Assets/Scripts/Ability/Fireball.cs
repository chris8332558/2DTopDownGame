using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] private string targetTag;
    [SerializeField] private GameObject explosionPrefab;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Fire(Vector2 direction)
    { 
        body.AddForce(direction * speed, ForceMode2D.Impulse);
	}

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Explode();
            Destroy(gameObject);
		}
    }
}
