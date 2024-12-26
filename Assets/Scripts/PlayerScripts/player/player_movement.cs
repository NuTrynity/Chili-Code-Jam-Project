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
    public float blindZoneDistance;

    public tentacles legUp;
    public tentacles legDown;
    private Rigidbody2D rb;
    private float angle;
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // calculating distance to mouse for blind zone
        mousePos.z = 0;
        float distance = Vector3.Distance(transform.position, mousePos);
        
        if (canControl)
        {
            // detecting angle to mouse
            if (distance > blindZoneDistance)
            {
               Vector3 direction = mousePos - transform.position;
               angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }

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
