using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCount : MonoBehaviour
{
    public int coinCounter;
    public TMP_Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        coinText.text = "Coins: " + coinCounter;
    }

    void OnDestroy()
    {
        // Save the player's score to PlayerPrefs when the scene is destroyed
        PlayerPrefs.SetInt("PlayerScore", coinCounter);
        PlayerPrefs.Save();
    }


    // Triggered when the ball comes in contact with obstacles or coins.
    private void OnTriggerEnter(Collider ElementCollider)
    {
        if (ElementCollider.gameObject.CompareTag("CoinTag"))  //Coin collected.
        {
            ElementCollider.gameObject.SetActive(false);//deactivate or disappear the coin
            coinCounter++;  
            //display the updated value.
            coinText.text = "Coins: " + coinCounter;
            

         }

       if (ElementCollider.gameObject.CompareTag("Obstacle"))  // Trigger Used to detect the end of game
        {
            SceneManager.LoadScene("EndGame");
        }

        /* if (ElementCollider.gameObject.CompareTag("Stealingwall"))   // obstacles to hinder progress by stealing the coins.
        {
            coinCounter = 0;
            coinText.text = "Coins: " + coinCounter;
        }using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int playerScore;

    void Update()
    {
        // Update the player's score as necessary
        playerScore = CalculateScore();
    }

    void OnDestroy()
    {
        // Save the player's score to PlayerPrefs when the scene is destroyed
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }
}

       */

    }
}
