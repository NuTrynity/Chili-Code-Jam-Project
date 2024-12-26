using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int max_health = 25;
    public int health;

    public AudioSource takingDamage;
    public AudioSource death;

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
        }
    }

    public void Die()
    {
          
    }
}
