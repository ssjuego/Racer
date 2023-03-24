using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // Get the player's score from PlayerPrefs and display it
        int playerScore = PlayerPrefs.GetInt("PlayerScore");
        scoreText.text = $"Your Score is {playerScore}";
    }
}


