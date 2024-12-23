using Pathfinding;
using UnityEngine;

public class target_manager : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;

    private void Awake() {
        destinationSetter = gameObject.GetComponentInParent<AIDestinationSetter>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ChangeTarget(other.transform);
        }
    }

    public void ChangeTarget(Transform target) {
        destinationSetter.target = target;
    }
}
