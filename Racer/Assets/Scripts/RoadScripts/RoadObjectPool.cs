using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectPool : MonoBehaviour
{
    public static RoadObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<GameObject> objectToPool;
    public int amountToPool;                      // amount to pool of each variant


    void Awake()
    {
        SharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)  
        {
            for (int j = 0; j < objectToPool.Count; j++) 
            {
                GameObject obj = (GameObject)Instantiate(objectToPool[j]); // Create gameobject
                obj.SetActive(false);    // deactivate gameobject
                pooledObjects.Add(obj);  //add to pool.
            }
        }

    }

    public GameObject GetPooledObject()
    {
        //1
        int i = 0;
        while(i < pooledObjects.Count)
        {
            int x = Random.Range(0, pooledObjects.Count);
            if (!pooledObjects[x].activeInHierarchy)
            {
                return pooledObjects[x];
            }
            i++;
        }
        //3   
        return null;
    }
}
