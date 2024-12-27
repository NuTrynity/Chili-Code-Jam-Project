using Pathfinding;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float max_health;
    public float health;

    public float curRegenTime;
    public bool isPlayer;
    public ParticleSystem[] deathEffect;
    public GameObject[] limbs; 
    public Image damageIndicator;
    public bool useDamageIndicator;
    public AudioSource[] deathSound;
    public AudioSource[] damageTakingSound;

    private Rigidbody2D rb;
    private void Start()
    {
        health = max_health;
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            int randomSound = Random.Range(0, damageTakingSound.Length);
            damageTakingSound[randomSound].Play();
        }
        if (health <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
        if (useDamageIndicator)
        {
            float normalizedHealth = Mathf.Clamp01(health / max_health);
            damageIndicator.color = new Color(1, 1, 1, 1 - normalizedHealth);
        }
        Regen();
    }
    public void Die()
    {
        int randomSound = Random.Range(0, deathSound.Length);
        deathSound[randomSound].Play();
        if (isPlayer)
        {
            rb.angularVelocity = Random.Range(-25, 25);
            player_movement pm = GetComponent<player_movement>();
            for(int i = 0; i < limbs.Length; i++)
            {
                if (limbs[i].GetComponent<tentacles>())
                {
                    limbs[i].GetComponent<tentacles>().enabled = false;
                }
                if(limbs[i].GetComponent<HingeJoint2D>())
                {
                    limbs[i].GetComponent<HingeJoint2D>().enabled = false;
                }
                player_movement lpm = limbs[i].GetComponent<player_movement>();
                limbs[i].transform.SetParent(null);
                Destroy(lpm);
            }
            for(int i = 0;i < deathEffect.Length; i++)
            {
                deathEffect[i].Play();
            }
            Destroy(pm);
            Destroy(this);
        }
        else
        {
            Destroy(gameObject.GetComponent<AIPath>());
        }
    }
    public void Regen()
    {
        if (curRegenTime > 0)
        {
            curRegenTime -= 1 * Time.deltaTime;
        }
        if (health < max_health && curRegenTime > 0)
        {
            health += 1 * Time.deltaTime;
        }
    }
}
