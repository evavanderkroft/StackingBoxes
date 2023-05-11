
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoremanager : MonoBehaviour
{
    public static scoremanager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score = 0;
    private int newScore;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";

    }
    // Update is called once per frame
    void Update()
    {
    }


    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        PlayerPrefs.SetInt("Score", score);
        UpdateHighscore(score);
    }



    public void UpdateHighscore(int newHighscore)
    {
        Debug.Log("UpdateHighscore() function called with new highscore: " + newHighscore);
        if (newHighscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", newHighscore);
            Debug.Log("New highscore is greater than saved highscore");
        }
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", 0).ToString();

    }

}
