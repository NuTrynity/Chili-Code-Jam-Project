using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public string sceneName;
    public void LoadNamedScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
