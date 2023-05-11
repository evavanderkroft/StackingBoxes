using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        // highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", 0).ToString();
        finalScoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void Restart()
    {
        Debug.Log("restart game");
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
