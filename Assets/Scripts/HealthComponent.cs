using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int max_health = 5;
    private int health;

    public HealthComponent()
    {
        health = max_health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
