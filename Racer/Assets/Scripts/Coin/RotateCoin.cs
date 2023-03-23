using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    Vector3 turnCoin;

    // Update is called once per frame
    void Update()
    {
        turnCoin = new Vector3(0, 0, 1);
        transform.Rotate(turnCoin ); // Rotating the coin slowly.
    }
}
