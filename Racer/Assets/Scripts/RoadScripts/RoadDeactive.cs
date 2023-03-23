using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeactive : MonoBehaviour
{
    
    [SerializeField] int distanceOffset = 150;
    [SerializeField] int checkTime = 3;
    // Update is called once per frame
    void CheckLocation()
    {
        if((PlayerLocation.Z_Position - distanceOffset) > transform.position.z)
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        InvokeRepeating("CheckLocation", 0, checkTime);
    }
}
