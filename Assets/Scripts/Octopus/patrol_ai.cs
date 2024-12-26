using System.Collections;
using UnityEngine;

public class patrol_ai : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "PatrolNode(Clone)")
        {
            if (targetManager.destinationSetter != null)
            {
                Debug.Log("Patrol node reached");
            }
        }
    }

    public Vector2 RandPath()
    {
        float randomDistance = Random.Range(1f, patrol_distance);
        Vector2 new_path = transform.position + new Vector3(Random.Range(-randomDistance, randomDistance), Random.Range(-randomDistance, randomDistance), 0);
        return new_path;
    }

    private IEnumerator Patrol()
    {
        GameObject new_patrol_node = Instantiate(patrol_node);

        yield return new WaitForSeconds(Random.Range(3f, patrol_interval));

        new_patrol_node.transform.position = RandPath();
        targetManager.destinationSetter.target = new_patrol_node.transform;

        StartCoroutine(Patrol());
        StartCoroutine(PatrolPointDestroy(new_patrol_node));
    }

    private IEnumerator PatrolPointDestroy(GameObject patrolNode) {
        yield return new WaitForSeconds(5f);
        Destroy(patrolNode);
    }
}
