using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{
    public static PlayerLocation globalInstance;
    public static float Z_Position;
    
    void Awake()
    {
        globalInstance = this;
    }

    private void Start()
    {
        InvokeRepeating("PlayerLocationUpdate", 0, 1f);
    }
    // Update is called once per frame
    void PlayerLocationUpdate()
    {
        Z_Position = transform.position.z;
       
    }
}
