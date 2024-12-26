using UnityEngine;

public class waterSurface : MonoBehaviour
{
    private Rigidbody2D playerRb;
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            playerRb.gravityScale = 0;
            playerRb.angularDamping = playerOriginAngularDamping;
            playerRb.linearDamping = playerOriginLinearDamping;
        }
    }
}
