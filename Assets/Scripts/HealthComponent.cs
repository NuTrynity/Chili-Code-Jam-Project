using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int max_health = 5;
    public AudioSource takingDamage;
    public AudioSource death;

    private int health;
    
    public HealthComponent()
    {
        health = max_health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        takingDamage.Play();
        
        if (health <= 0)
        {
            death.Play();
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
