using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class SpawnerScript : MonoBehaviour
{
    public GameObject spawnedObject;
    private int i;
    private int spawnedCount;
    public int maxSpawnCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnedCount = GameObject.FindGameObjectsWithTag("Spawner").Length; 
        if (spawnedCount <= maxSpawnCount && i >= 1000) 
        {
            SpawnObject();
            i = 0;
        }
        else
        {
            i++;
        }
       
    }

    void SpawnObject()
    {
        Instantiate(spawnedObject, spawnedObject.transform);
    }
}
