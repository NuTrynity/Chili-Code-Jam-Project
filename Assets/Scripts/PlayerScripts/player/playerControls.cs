using System.Xml;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    [Header("LEGS")]
    public tentacles legUp;
    public tentacles legDown;
    private player_movement pm;
    private player_properties pp;
    private HealthComponent hc;
    private Rigidbody2D rb;


    public GameObject harpoon;
    public GameObject flashlight;
    public GameObject lamp;
    public bool upArmIsBusy;
    public bool downArmIsBusy;
    private void Start()
    {
        hc = GetComponent<HealthComponent>();
        pm = GetComponent<player_movement>();
        pp = GetComponent<player_properties>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //movement
        if(Input.GetKey(KeyCode.W) && pm.canControl)
        {
            rb.AddForce(transform.right * pp.move_speed);
            legUp.wiggleSpeed = 5f;
            legDown.wiggleSpeed = -5f;
            legUp.wiggleMagnitude = 20;
            legDown.wiggleMagnitude = 20;
        }
        if (Input.GetKeyUp(KeyCode.W) && pm.canControl)
        {
            legUp.wiggleSpeed = 0.5f;
            legDown.wiggleSpeed = -0.5f;
            legUp.wiggleMagnitude = 5;
            legDown.wiggleMagnitude = 5;
        }

        // inventory system
        Inventory();
    }
    private void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && pp.flashlights > 0)
        {
            if (flashlight.active == false)
            {
                if(upArmIsBusy)
                {
                    SetDownArmOff();
                }
                upArmIsBusy = true;
                flashlight.SetActive(true);
            }
            else
            {
                upArmIsBusy = false;
                flashlight.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && pp.lamps > 0)
        {
            if (lamp.active == false)
            {
                if(upArmIsBusy)
                {
                    SetDownArmOff();
                }
                upArmIsBusy = true;
                lamp.SetActive(true);
            }
            else
            {
                upArmIsBusy = false;
                lamp.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && pp.harpoons > 0)
        {
            if (harpoon.active == false)
            {
                if (downArmIsBusy)
                {
                    SetUpArmOff();
                }
                downArmIsBusy = true;
                harpoon.SetActive(true);
            }
            else
            {
                downArmIsBusy = false;
                harpoon.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            pp.injections--;
            hc.curRegenTime = 15;
        }
    }
    private void SetUpArmOff()
    {
        harpoon.SetActive(false);
    }
    private void SetDownArmOff()
    {
        flashlight.SetActive(false);
        lamp.SetActive(false);
    }
}
