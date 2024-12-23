using UnityEngine;

public class bolt : MonoBehaviour
{
    public int damage = 1;
    public int speed = 10;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * speed;
    }

    // When bolt collides with an enemy, deal damage to it
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthComponent health = other.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
