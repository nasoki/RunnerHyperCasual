using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public bool isLevelCompleted;
    public CharacterController characterController;
    public bool resultScreen;
    public TMP_Text FinalScoreText;
    public GameObject endOfLevelPanel;
    public int finalScore;
    void Start()
    {
        endOfLevelPanel.SetActive(false);
        isLevelCompleted = false;
        resultScreen = false;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLevelCompleted)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("EndPoint").transform.position, 10 * Time.deltaTime);
        }

        if(transform.position == GameObject.FindGameObjectWithTag("EndPoint").transform.position)
        {
            resultScreen = true;
        }

        if (resultScreen)
        {
            endOfLevelPanel.SetActive(true);
        }
        switch (GameStateManager.totalScore)
        {
            case < 31:
                finalScore = GameStateManager.totalScore * 2;
                break;
            case < 61:
                finalScore = GameStateManager.totalScore * 3;
                break;
            case < 101:
                finalScore = GameStateManager.totalScore * 4;
                break;
            case < 141:
                finalScore = GameStateManager.totalScore * 5;
                break;
            case < 181:
                finalScore = GameStateManager.totalScore * 6;
                break;
            default:
                finalScore = GameStateManager.totalScore * 1;
                break;
        }
        FinalScoreText.text = "Your final score is: " + finalScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            this.GetComponent<Move>().enabled = false;
            isLevelCompleted = true;
        }
    }
}
