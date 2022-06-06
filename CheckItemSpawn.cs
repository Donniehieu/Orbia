using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItemSpawn : MonoBehaviour
{
    public static bool coinSpawn, fuelSpawn;
    public void SpawnOb(GameObject  itemSpawn, Vector3[] posSpawnArray)
    {
        for (int i = 0; i < posSpawnArray.Length; i++)
        {
            Instantiate(itemSpawn, posSpawnArray[i], Quaternion.identity);
        }
        CheckSpawnItem(itemSpawn);
    }

    private void CheckSpawnItem(GameObject item)
    {
        if (item.name == StringHelper.CoinName)
        {
            coinSpawn = true;
        }
    }
}
