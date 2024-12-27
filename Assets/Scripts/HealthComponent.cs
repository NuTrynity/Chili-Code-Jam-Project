using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float max_health;
    public float health;

    public float curRegenTime;

    public AudioSource deathSound;
    public AudioSource damageTakingSound;
    private void Start()
    {
        health = max_health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        damageTakingSound.Play();
        if (health <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
        Regen();
    }
    public void Die()
    {
        deathSound.Play();
        if (gameObject.CompareTag("enemy"))
        {
            
        }
        else
        {
            GetComponent<player_movement>().GameOver();
        }
        Destroy(this);
    }
    public void Regen()
    {
        curRegenTime -= 1 *Time.deltaTime;
        if (health < max_health && curRegenTime > 0)
        {
            health += 1 * Time.deltaTime;
        }
    }
}
