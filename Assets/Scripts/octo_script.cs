using UnityEngine;

public class player_script : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 direction;
    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursor_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursor_pos, speed * Time.deltaTime);

        /*
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * speed);
        }
        */
    }
}
