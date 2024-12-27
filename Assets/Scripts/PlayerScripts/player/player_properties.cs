using UnityEngine;

public class player_properties : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float move_speed = 6.0f;
    public float rotation_speed = 10.0f;
    [Header("INVENTORY")]
    public int bolts;
    public int taskObjects;
    // objects that player can hold in hand 
    public int harpoons;
    public int flashlights;
    public int lamps;
    public int injections;
}
