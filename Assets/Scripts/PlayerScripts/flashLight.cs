using Unity.VisualScripting;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    public float distance;
    public LayerMask layersToCollide;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layersToCollide);
        if (hit && hit.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.LogError("Enemy Detected");
        }
    }
}
