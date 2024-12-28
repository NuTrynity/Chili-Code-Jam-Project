using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public void OnPlayClicked() {
        sceneLoader.ChangeScene("day1");
    }
}
