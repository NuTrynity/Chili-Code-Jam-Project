using UnityEngine;

public class enemyDamageZone : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            collision.GetComponent<HealthComponent>().TakeDamage(damage);
        }
    }
}
