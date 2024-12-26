using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class bolt : MonoBehaviour
{
    public int damage = 1;
    public int speed = 50;

    public bool dealedDamage;
    private item item;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        item = GetComponent<item>();
        gameObject.SetActive(true);
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        item.pickUpAble = false;
        dealedDamage = false;
    }
    // When bolt collides with an enemy, deal damage to it
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && dealedDamage == false)
        {
            HealthComponent health = other.gameObject.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.TakeDamage(damage);
                GetComponent<BoxCollider2D>().enabled = false;
                rb.gravityScale = 0;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0;
                StartCoroutine(PenetraringEnemy(other.gameObject));
                dealedDamage = true;
            }
        }
        
    }
    private IEnumerator PenetraringEnemy(GameObject parentToSet)
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.02f);
        gameObject.transform.SetParent(parentToSet.transform);
        Destroy(rb);
    }
}
