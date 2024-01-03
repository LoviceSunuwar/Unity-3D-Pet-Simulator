using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject genObestacle;
    public Transform[] pos;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2); // now every 4 second, this calls the funciton spawnobstacles.
    }

    public void SpawnObstacle()
    {
        // Instantiate function allows us to generate an object so (what , where (Vector3), rotation)
        // ( what to generate -> genObstacle, where to -> on the array of transform we kept, Quaternion gives us rotation -> identity is used so it starts in its original position)
        Instantiate(genObestacle, pos[Random.RandomRange(0, pos.Length)].position, Quaternion.identity);
    }

}
