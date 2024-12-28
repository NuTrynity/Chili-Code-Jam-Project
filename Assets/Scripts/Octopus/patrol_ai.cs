using Pathfinding;
using UnityEngine;
public class PatrolAI : MonoBehaviour
{
    public AIDestinationSetter targetManager;
    public Transform[] patrol_points;

    public bool aggro = false;
    private int patrol_index = 0;

    public void SetAggro(bool value)
    {
        aggro = value;
    }

    private void FixedUpdate() {
        if (aggro == true)
        {
            return;
        }

        if (Vector3.Distance(transform.position, patrol_points[patrol_index].position) < 1f)
        {
            IncreasePatrolIndex();
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
}
