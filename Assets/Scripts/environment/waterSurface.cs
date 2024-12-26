using UnityEngine;

public class waterSurface : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Rigidbody2D enemyRb;
    private float originalEnemyAngular;
    private float originalEnemyLinear;
    private float playerOriginAngularDamping;
    private float playerOriginLinearDamping;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.gravityScale = 2;
            playerOriginAngularDamping = playerRb.angularDamping;
            playerOriginLinearDamping = playerRb.linearDamping;
            playerRb.angularDamping = 0;
            playerRb.linearDamping = 0;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemyRb = collision.gameObject.GetComponent<Rigidbody2D> ();
            enemyRb.gravityScale = 1;
            originalEnemyAngular = enemyRb.angularDamping;
            originalEnemyLinear = enemyRb.linearDamping;
            enemyRb.angularDamping = 0;
            enemyRb.linearDamping = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            playerRb.gravityScale = 0;
            playerRb.angularDamping = playerOriginAngularDamping;
            playerRb.linearDamping = playerOriginLinearDamping;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyRb.gravityScale = 0;
            enemyRb.angularDamping = originalEnemyAngular;
            enemyRb.linearDamping = originalEnemyLinear;
        }
    }
}
