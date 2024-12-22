using UnityEngine;

public class player_script : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.AddForce(transform.right * speed);
        }
        /*
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * speed);
        }
        */
    }
}
