using UnityEngine;

public class light_detector : MonoBehaviour
{
    private target_manager target_manager;
    public Transform retreat_point;

    private void Awake() {
        target_manager = transform.parent.GetComponentInChildren<target_manager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Light") && target_manager.can_chase == true) {
            target_manager.ChangeTarget(retreat_point);
        }
    }
}
