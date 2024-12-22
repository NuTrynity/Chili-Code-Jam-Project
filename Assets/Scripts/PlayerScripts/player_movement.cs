using UnityEngine;

public class player_movement : MonoBehaviour
{
    public player_properties mp;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * mp.move_speed);
        }
        else {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
