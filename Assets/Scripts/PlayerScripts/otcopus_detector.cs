using UnityEngine;

public class otcopus_detector : MonoBehaviour
{
    public GameObject retreat_point;

    public LayerMask collidableLayers;
    public Transform shootPoint;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Vector3 partLighed = other.ClosestPoint(transform.position);
            RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, (partLighed - shootPoint.position).normalized, 35, collidableLayers);
            if(hit && hit.collider == other)
            {
                Debug.Log("Octopus Detected");
                other.GetComponent<target_manager>().ChangeTarget(retreat_point.transform);
            }
        }
    }
}
