using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [Header("Content")]
    [Tooltip("The object that will content the block")]
    [SerializeField] private Structs.id wantedPlant = Structs.id.empty;
    public bool content = false;
    public bool occupied = false;

    [Header("Grid ID")]
    public bool newBlock = true;
    public int row = 0;
    public int column = 0;

    public bool Place(Structs.id seed)
    {
        if (occupied)
            return false;

        occupied = true;

        PlantPooler[] pools = FindObjectsOfType<PlantPooler>();
        foreach(PlantPooler pool in pools)
        {
            if (seed == pool.ID)
            {
                Debug.Log("Got the Pool: " + pool.ID.ToString());
                GameObject plant = pool.GetObject();
                plant.GetComponent<GrowingPlant>().giveLifeToPlant();
                plant.transform.parent = transform;
                plant.SetActive(true);
                return true;
            }
        }
        return true;
    }
}
