using Pathfinding;
using UnityEngine;
public class PatrolAI : MonoBehaviour
{
    public AIDestinationSetter targetManager;
    public Transform[] patrol_points;

    public bool aggro = false;
    public float distance = 5f;
    private int patrol_index = 0;

    public void SetAggro(bool value)
    {
        aggro = value;
    }

    public void PatrolPoint() {
        if (aggro == true)
        {
            return;
        }

        targetManager.target = patrol_points[patrol_index];
    }

    private void IncreasePatrolIndex()
    {
        patrol_index++;

        if (patrol_index >= patrol_points.Length)
        {
            patrol_index = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.LogError(Vector3.Distance(transform.position, patrol_points[patrol_index].position));
        if (other.CompareTag("PatrolNode") && Vector3.Distance(transform.position, patrol_points[patrol_index].position) < distance)
        {
            IncreasePatrolIndex();
            PatrolPoint();
        }
    }
}
