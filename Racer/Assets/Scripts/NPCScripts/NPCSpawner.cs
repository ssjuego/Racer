using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] GameObject Pipes;
    [SerializeField] Transform player;
    [SerializeField] float spawnRate = 1;
    [SerializeField] float zSpawn = 500f;
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
                
                CarMaker();
                timer = 0;
            }
        }
    }


    void CarMaker()
    {
        GameObject pipeObstacle = NPCPooler.SharedInstance.GetPooledObject();
        if (pipeObstacle != null)
        {
            pipeObstacle.transform.position = transform.position;
            pipeObstacle.SetActive(true);
            transform.position = new Vector3(transform.position.x, player.position.y, player.position.z + zSpawn);

        }

    }
}
