using UnityEngine;

public class player_movement : MonoBehaviour
{
    public GeneralMovement gm;
    public player_properties mp;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = transform.right * mp.move_speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = -transform.right * mp.move_speed / 2;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        transform.rotation = gm.LookAt(gm.GetMousePosition(), mp.rotation_speed);
    }
}
