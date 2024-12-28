using JetBrains.Annotations;
using UnityEngine;

public class deathTrig : MonoBehaviour
{
    public GameObject deathScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("player"))
        {
            deathScreen.SetActive(true);
            Destroy(collision.gameObject.GetComponent<player_movement>());  
        }
    }
}
