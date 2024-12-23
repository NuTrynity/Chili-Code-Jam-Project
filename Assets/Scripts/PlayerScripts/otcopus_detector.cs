using UnityEngine;

public class otcopus_detector : MonoBehaviour
{
    public GameObject retreat_point;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<target_manager>().destinationSetter.target = retreat_point.transform;
        }
    }
}
