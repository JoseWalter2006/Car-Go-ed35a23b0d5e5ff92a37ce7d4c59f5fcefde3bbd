using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timeText;

    float gameTime;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Vidas: " + lives;
    }
}