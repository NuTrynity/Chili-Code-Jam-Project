using UnityEngine;

public class flashLightRayCast : MonoBehaviour
{
    public float distance;
    public LayerMask layersToCollide;
    public int chanseToScare;
    private float timer;
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layersToCollide);
        if (hit && hit.collider.gameObject.CompareTag("Enemy"))
        {
            float random = Random.Range(0, 100);
            if (random <= chanseToScare && timer <= 0)
            {
                hit.collider.gameObject.GetComponent<target_manager>().ScareAway();
                timer = 5;
            }
        }
    }
}
