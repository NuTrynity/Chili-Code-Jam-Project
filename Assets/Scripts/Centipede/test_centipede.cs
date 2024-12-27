using UnityEngine;

public class test_centipede : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D body;

    private void FixedUpdate() {
        body.AddForce(transform.right * speed);
    }
}