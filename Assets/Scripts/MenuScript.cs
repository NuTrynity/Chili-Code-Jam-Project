using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject sceneLoader;

    public void OnPlayClicked() {
        sceneLoader.GetComponent<SceneLoader>().ChangeScene("day1");
    }
}
