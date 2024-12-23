using UnityEngine;

public class otcopus_detector : MonoBehaviour
{
    public GameObject retreat_point;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Enemy Detected");
        
        if (other.CompareTag("Enemy")) {
            Debug.Log("Enemy Flashed");
            other.GetComponent<target_manager>().ChangeTarget(retreat_point.transform);
        }
    }
}
