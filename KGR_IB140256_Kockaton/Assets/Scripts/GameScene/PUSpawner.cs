using System.Collections.Generic;
using UnityEngine;
public class PUSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject PU1Prefab;
    public GameObject PU2Prefab;

    void Start()
    {
        SpawnPU();
    }

    void SpawnPU()
    {
        int rndNumber = Random.Range(0, 12);

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if (i == rndNumber)
            {
                int rnd = Random.Range(0, 2);

                if (rnd == 0)
                {
                    Instantiate(PU1Prefab, spawnPoint[i].position, Quaternion.identity);
                }
                else
                {
                    Instantiate(PU2Prefab, spawnPoint[i].position, Quaternion.identity);
                }
            }
        }
    }
}
