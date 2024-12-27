using UnityEngine;

public class effectZone : MonoBehaviour
{
    public string tag;
    public ParticleSystem effect;
    public bool playAtClosestPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag(tag))
        {
            if (playAtClosestPoint)
            {
                Vector3 detectPos = collision.ClosestPoint(transform.position);
                effect.transform.position = detectPos;
            }
            effect.Play();
        }
    }
}
