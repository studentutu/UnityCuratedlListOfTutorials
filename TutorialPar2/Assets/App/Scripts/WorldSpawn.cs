﻿using System;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class WorldSpawn : MonoBehaviour
{
    public GameObject block1;
    public GameObject Plane;
    public int worldWidth = 10;
    public int worldHeight = 10;

    public float spawnSpeed = 0;

    void Start()
    {
        GenerateCubes();
        // StartCoroutine(CreateWorld());
        Plane.transform.localScale = new Vector3(worldWidth, worldHeight, 5f);
    }

    IEnumerator CreateWorld()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);

            for (int z = 0; z < worldHeight; z++)
            {
                yield return new WaitForSeconds(spawnSpeed);

                GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                // block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x - 10, 0, z - 10);
            }
        }
    }

    private async void GenerateCubes()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            await Task.Delay(1000);
            if (this == null)
            {
                return;
            }
            for (int z = 0; z < worldHeight; z++)
            {
                await Task.Delay(1000);
                if (this == null)
                {
                    return;
                }

                GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                // block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x , 0, z );
            }
        }
    }
}