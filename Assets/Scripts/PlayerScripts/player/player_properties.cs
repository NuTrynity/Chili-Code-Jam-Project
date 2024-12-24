using UnityEngine;

public class player_properties : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float move_speed = 6.0f;
    public float rotation_speed = 10.0f;
    [Header("INVENTORY")]
    public float bullets;
    public float taskObjects;
    // objects that player can hold in hand 
    public float harpoons;
    public float flashlights;
    public float lamps;
}
