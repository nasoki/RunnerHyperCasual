using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static int totalScore = 40;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public Text scoreText;
    public static bool isGameStarted;
    public GameObject startingText;
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        scoreText.text = "Color Power: " + totalScore;

        if (totalScore <= 0)
        {
            gameOver = true;
        }

        if (!gameOver)
        {
            gameOverPanel.SetActive(false);
        }
    }
}
