using Unity.VisualScripting;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public player_properties pp;

    public bool canControl = true;
    public float maxRotationAngle;
    private float torsoAngle;
    private float startingAngle;
    public Transform torso;
    public bool useLimits;
    public bool rotateWhenPressingRmb;
    public float angularVelocityIncreaser;

    public tentacles legUp;
    public tentacles legDown;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingAngle = transform.eulerAngles.z;
    }
    private void Update()
    {
        // rotation
        if (rotateWhenPressingRmb)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                RotateTowardCursor();
            }
        }
        else
        {
            RotateTowardCursor();
        }
    }

    private void RotateTowardCursor()
    {
        if (canControl)
        {
            // detecting angle to mouse
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //limiting if use limits = true
            if (useLimits)
            {
                torsoAngle = torso.eulerAngles.z + startingAngle;

                float relativeAngle = Mathf.DeltaAngle(torsoAngle, angle);
                relativeAngle = Mathf.Clamp(relativeAngle, -maxRotationAngle, maxRotationAngle);
                angle = torsoAngle + relativeAngle;
            }
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, pp.rotation_speed * Time.deltaTime);
        }
    }
}
