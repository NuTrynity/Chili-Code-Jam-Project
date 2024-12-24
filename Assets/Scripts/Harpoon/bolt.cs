using UnityEngine;

public class bolt : MonoBehaviour
{
    public int damage = 1;
    public int speed = 10;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        // Set bolt's rotation to be the same as the parent's rotation
        // transform.rotation = transform.parent.rotation;
    }

    private void FixedUpdate() {
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
    }
}
