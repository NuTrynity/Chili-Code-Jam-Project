using Unity.VisualScripting;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    public float distance;
    public LayerMask layersToCollide;
    public GameObject dotForFlashLight;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layersToCollide);
        if (hit)
        {
            dotForFlashLight.SetActive(true);
            dotForFlashLight.transform.position = hit.point;
        }
        else
        {
            dotForFlashLight.SetActive(false);
        }
    }
}
