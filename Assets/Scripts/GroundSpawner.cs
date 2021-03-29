﻿using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;


    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);  //Instantiate is how we spawn (make more) object in unity, 
                                                                                         // first argument is object we wnat to spawn,
                                                                                         //second argument is where we want to spawn
                                                                                         // third one, determine the rotation
                                                                                         //Quaternion.identity means no rotation

        nextSpawnPoint = temp.transform.GetChild(1).transform.position;             // GroundTile has 2 children, Plane and NextSpawnPoint
                                                                                    // we want the second child

        //temp.GetComponent<GroundTile>().SpawnWall();

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
        
    }

   
}
