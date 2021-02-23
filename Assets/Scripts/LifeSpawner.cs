using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] lives;

    private float timeBtwSpawns = 8;

    int index = 0;
    

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player != null) // when the player dies
        {
            if (timeBtwSpawns <= 0)
            {
                timeBtwSpawns = 8;

                index++;
                if(index == 4)
                {
                    index = 0;
                }
                GameObject randomLives = lives[0];

                Instantiate(randomLives, spawnPoints[index].position, Quaternion.identity); 

               
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
