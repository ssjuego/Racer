using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCount : MonoBehaviour
{
    public int coinCounter;
    public float speed;
    public TMP_Text coinText;
    [Space]
    public TMP_Text SpeedText;
   
    

    private Vector3 lastPosition;
    private float lastUpdateTime;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
        coinText.text = "Coins: " + coinCounter;
        speed = 0;
        SpeedText.text = $"Speed: {speed}M/s";
        lastPosition = transform.position;
        lastUpdateTime = Time.time;

    }

    void OnDestroy()
    {
        // Save the player's score to PlayerPrefs when the scene is destroyed
        PlayerPrefs.SetInt("PlayerScore", coinCounter);
        PlayerPrefs.Save();
    }

    private void FixedUpdate()
    {
        // Calculate the elapsed time since the last update
        float deltaTime = Time.time - lastUpdateTime;

        // Calculate the distance traveled since the last update
        Vector3 displacement = transform.position - lastPosition;

        // Calculate the velocity in meters per second
        Vector3 velocity = new Vector3((displacement.x / deltaTime),0f, displacement.z / deltaTime);

        // Store the current position and time for the next update
        lastPosition = transform.position;
        lastUpdateTime = Time.time;

        // Velocity printing
        speed = velocity.magnitude;
        SpeedText.text = $"Speed: {(int)speed}M/s";
    }

    // Triggered when the player comes in contact with obstacles or coins.
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

       
    }
}
