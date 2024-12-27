using UnityEngine;

public class taskManager : MonoBehaviour
{
    public GameObject personOnBoat;
    public GameObject levelEndTrigger;
    public void Day1TaskComplete()
    {
        personOnBoat.SetActive(false);
        levelEndTrigger.SetActive(true);   
    }
    public void Day2TaskComplete()
    {
        levelEndTrigger.SetActive(true);
    }
}
