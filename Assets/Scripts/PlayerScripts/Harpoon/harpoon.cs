using System.Collections;
using UnityEngine;

public class harpoon : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform firePoint;
    public float cooldown = 2f;

    private bool can_shoot = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (can_shoot)
            {
                ShootBolt();
                StartCoroutine(StartCooldown(cooldown));
            }
        }
    }

    private void ShootBolt()
    {
        GameObject new_bolt = Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
        new_bolt.GetComponent<bolt>().speed = 25;

        boltPrefab.SetActive(false);
    }

    private IEnumerator StartCooldown(float cooldown_timer)
    {
        can_shoot = false;
        yield return new WaitForSeconds(cooldown_timer);
        can_shoot = true;
        boltPrefab.SetActive(true);
    }
}
