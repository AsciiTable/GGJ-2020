using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] protected GameObject objectPrefab = null;
    [SerializeField] protected int poolSize = 0;

    //List that's going to hold all the object
    [SerializeField] protected List<GameObject> objectPool = new List<GameObject>();

    private void Start()
    {
        FillPool();
    }

    public void FillPool()
    {
        while(objectPool.Count < poolSize)
        {
            MakeObject();
        }
    }

    public void ClearPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            objectPool[i].SetActive(false);
        }
    }

    public List<GameObject> GetPool()
    {
        return objectPool;
    }

    public void DeletePool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            Destroy(objectPool[i]);
        }
        objectPool = new List<GameObject>();
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
                return objectPool[i];
        }
        poolSize++;
        return MakeObject();
    }

    protected GameObject MakeObject()
    {
        GameObject obj = Instantiate(objectPrefab);
        obj.transform.parent = transform;
        obj.SetActive(false);
        objectPool.Add(obj);

        return obj;
    }
}
