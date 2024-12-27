using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    public Rigidbody2D body;

    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Quaternion LookAt(Vector2 target, float rotationSpeed)
    {
        Vector3 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        return Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
