using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab;
    private Transform player;
    private float spawnZ = 48f;
    private float groundLenght = 100.0f;
    private float safeZone = 72;
    private int amnGroundOnScreen = 3;
    private List<GameObject> activeGrounds;

    void Start()
    {
        activeGrounds = new List<GameObject>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnGroundOnScreen; i++)
        {
            SpawnGround();
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > (spawnZ - amnGroundOnScreen * groundLenght))
        {
            SpawnGround();
            DeleteGround();
        }
    }

    public void SpawnGround()
    {
        GameObject go;
        go = Instantiate(groundPrefab) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLenght;
        activeGrounds.Add(go);
    }

    public void DeleteGround()
    {
        Destroy(activeGrounds[0]);
        activeGrounds.RemoveAt(0);
    }
}
