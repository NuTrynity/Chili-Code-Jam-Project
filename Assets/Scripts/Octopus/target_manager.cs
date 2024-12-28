using Pathfinding;
using UnityEngine;

public class target_manager : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;
    public PatrolAI patrol_ai;

    public float hide_time = 5f;
    public bool can_chase = true;

    private void Awake() {
        patrol_ai.PatrolPoint();
    }

    private void Update() {
        if (can_chase == false) {
            hide_time -= Time.deltaTime;
            Debug.Log("Hide Time: " + hide_time);
            if (hide_time <= 0) {
                can_chase = true;
                hide_time = 5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("player") && can_chase == true) {
            ChangeTarget(other.transform);
            patrol_ai.SetAggro(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("player"))
        {
            patrol_ai.PatrolPoint();
            patrol_ai.SetAggro(false);
        }
    }

    public void ChangeTarget(Transform target) {
        Debug.Log("Target Changed to " + target.name);
        destinationSetter.target = target;
    }
}
