using UnityEngine;

public class harpoon : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform firePoint;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ShootBolt();
        }
    }

    private void ShootBolt() {
        Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
    }
}
