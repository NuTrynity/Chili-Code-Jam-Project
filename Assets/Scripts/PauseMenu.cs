using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause_menu;
    public static bool is_paused = false;

    private void Start()
    {
        pause_menu.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        is_paused = !is_paused;

        pause_menu.SetActive(is_paused);

        if (is_paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
