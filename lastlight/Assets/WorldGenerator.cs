using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public List<GameObject> grounds;

    [SerializeField] int chunkOffset;
    GameObject player;
    GameObject dynamicObjects;
    int xCurrentChunk = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dynamicObjects = GameObject.FindWithTag("DynamicObjects");

        if (dynamicObjects == null)
        {
            Debug.LogError("An object with the tag 'DynamicObjects' does not exist, so world chunks cannot be spawned.");
        }
    }

    void Update()
    {
        while (xCurrentChunk < player.transform.position.x + chunkOffset * 3)
        {
            SpawnWorldChunk();
        }
    }

    void SpawnWorldChunk()
    {
        xCurrentChunk += chunkOffset;

        var ground = grounds[UnityEngine.Random.Range(0, grounds.Count)];

        Instantiate(ground, new Vector3(xCurrentChunk, -1, 0), Quaternion.identity, dynamicObjects.transform);
    }
}
