using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject blockPrefab;
    public GameObject blockPrefab2;

    bool Provjera(List<int> niz, int a)
    {
        foreach (var i in niz)
        {
            if (i == a)
            {
                return false;
            }
        }
        return true;
    }

    public List<int> CreateRandomList(int x)
    {
        List<int> list = new List<int>();

        for (int i = 0; i < x; i++)
        {
            int randomIndex = Random.Range(0, 5);

            if (Provjera(list, randomIndex))
            {
                list.Add(randomIndex);
            }
            else
            {
                i--;
            }
        }
        return list;
    }

    void Start()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        List<int> lista = CreateRandomList(4);

        Vector3 t = new Vector3(0, -0.5f, 0);

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            foreach (var item in lista)
            {
                int rnd = Random.Range(0, 2);
                if (i == item)
                {
                    if (rnd == 0)
                    {
                        Instantiate(blockPrefab, spawnPoint[i].position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(blockPrefab2, spawnPoint[i].position + t, Quaternion.identity);
                    }
                }
            }
        }
    }
}