using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;
    public TMP_Text statsText;

    void Awake()
    {
        instance = this;
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public void GameOver()
    {
        int score = ScoreManager.instance.score;

        int highScore = GetHighScore();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        statsText.text =
            "Score: " + score +
            "\nRecord: " + highScore;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }
}