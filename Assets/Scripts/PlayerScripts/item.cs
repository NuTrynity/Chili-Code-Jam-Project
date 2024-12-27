using System.Net.NetworkInformation;
using UnityEngine;

public class item : MonoBehaviour
{
    public int itemNumber;
    public bool pickUpAble;
    public ParticleSystem ableToPickUoEffect;
    public player_properties pp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && pickUpAble)
        {
            ableToPickUoEffect.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pp = collision.gameObject.GetComponent<player_properties>();
                PickUp();
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && pickUpAble)
        {
            ableToPickUoEffect.gameObject.SetActive(false);
        }
    }
    public void PickUp()
    {
        switch (itemNumber)
        {
            case 1:
                pp.bolts++;
                break;
            case 2:
                pp.taskObjects++;
                break;
            case 3:
                pp.harpoons++;
                break;
            case 4:
                pp.flashlights++;
                break;
            case 5:
                pp.lamps++;
                break;
        }
    }
}