using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnner : MonoBehaviour
{
    
    
    [SerializeField] float spawnRate = 8;
    [SerializeField] float zSpawn = 200f;
    private float timer = 0;
    
   

   
    // Update is called once per frame
    void Update()
    {
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                PipeMaker();
                timer = 0;
            }
        }
    }


    void PipeMaker()
    {
        GameObject pipeObstacle = RoadObjectPool.SharedInstance.GetPooledObject();
        if (pipeObstacle != null)
        {
            pipeObstacle.transform.position = transform.position;
            pipeObstacle.SetActive(true);
            transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpawn);

        }

    }
}