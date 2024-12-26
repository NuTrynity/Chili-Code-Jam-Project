using System.Collections;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float patrol_distance = 5f;
    public float patrol_interval = 5f;
    public GameObject patrol_node;

    private target_manager targetManager;

    private void Awake()
    {
        targetManager = GetComponentInChildren<target_manager>();

        StartCoroutine(Patrol());
    }

    // Randomizes a path around the octopus
    public Vector2 RandPath()
    {
        float randomDistance = Random.Range(1f, patrol_distance);
        Vector2 new_path = transform.position + new Vector3(Random.Range(-randomDistance, randomDistance), Random.Range(-randomDistance, randomDistance), 0);
        return new_path;
    }

    private IEnumerator Patrol() {
        yield return new WaitForSeconds(patrol_interval);

        GameObject new_patrol_node = patrol_node;

        Instantiate(new_patrol_node);
        new_patrol_node.transform.position = RandPath();
        targetManager.destinationSetter.target = new_patrol_node.transform;

        Debug.Log("Patrol Node: " + new_patrol_node.transform.position);
    }
}
