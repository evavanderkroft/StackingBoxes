using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc is clicked");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("game is resumed");
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("game is paused");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("load menu..");
        SceneManager.LoadScene("homescreen");
    }

    public void settings()
    {
        Debug.Log("load settings");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
