using UnityEngine;

public class playerBeginning : MonoBehaviour
{
    public float rotationForce = 150;
    public float force = -15;
    private player_movement pm;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<player_movement>();
         pm.useLimits = true;
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            pm.useLimits = false;
            rb.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
            rb.angularVelocity = rotationForce;
            rb.gameObject.transform.SetParent(null);
        }
    }
}
