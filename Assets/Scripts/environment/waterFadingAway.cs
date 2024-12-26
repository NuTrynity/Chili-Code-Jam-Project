using Unity.VisualScripting;
using UnityEngine;

public class waterFadingAway : MonoBehaviour
{
    private SpriteRenderer sr;
    public float maxDistance;
    public GameObject player;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        sr.color = new Color(0, 0, 0, distance);
    }
}
