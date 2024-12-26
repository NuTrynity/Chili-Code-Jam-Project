using Unity.VisualScripting;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    public float distance;
    public GameObject endOfFlashLightLight;
    public LayerMask layersToCollide;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layersToCollide);
        if(hit)
        {
            endOfFlashLightLight.SetActive(true);
            endOfFlashLightLight.transform.position = hit.point;
        }
        else
        {
            endOfFlashLightLight.SetActive(false);
        }
    }
}
