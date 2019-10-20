using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] GameObject collisionGround;
    [SerializeField] int chunkOffset;
    GameObject player;
    GameObject dynamicObjects;
    int xCurrentChunk = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dynamicObjects = GameObject.FindWithTag("DynamicObjects");
    }

    void Update()
    {
        while (xCurrentChunk < player.transform.position.x + chunkOffset)
        {
            SpawnWorldChunk();
        }
    }

    void SpawnWorldChunk()
    {
        xCurrentChunk += chunkOffset;

        Instantiate(collisionGround, new Vector3(xCurrentChunk, -1, 0), Quaternion.identity, dynamicObjects.transform);
    }
}
