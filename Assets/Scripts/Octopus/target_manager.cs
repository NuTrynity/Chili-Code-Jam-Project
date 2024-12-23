using Pathfinding;
using UnityEngine;

public class target_manager : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;

    private void Awake() {
        destinationSetter = transform.parent.GetComponent<AIDestinationSetter>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            destinationSetter.target = other.transform;
        }
    }
}
