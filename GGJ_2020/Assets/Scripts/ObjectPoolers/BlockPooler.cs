using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPooler : ObjectPooler
{
    public GameObject GetBlock()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy && objectPool[i].GetComponent<Block>().newBlock)
                return objectPool[i];
        }
        poolSize++;
        return MakeObject();
    }
}
