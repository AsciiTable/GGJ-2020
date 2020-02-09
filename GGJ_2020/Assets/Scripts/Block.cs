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
    public bool hasGrass = false;

    [Header("Grid ID")]
    public bool newBlock = true;
    public int row = 0;
    public int column = 0;
    private void OnEnable()
    {
        InstantiateGrass();
    }

    public bool InstantiateGrass() {
        if (hasGrass) {
            content = true;
            Place(Structs.id.grass, false);
        }
        return true;
    }

    public bool Place(Structs.id seed, bool OG)
    {
        if (occupied) {
            return false;
        }
            
        occupied = true;

        PlantPooler[] pools = FindObjectsOfType<PlantPooler>();
        foreach (PlantPooler pool in pools)
        {
            if (seed == pool.ID)
            {
                GameObject plant = pool.GetObject();
                plant.gameObject.GetComponent<GrowingPlant>().isOriginal = OG;
                //plant.GetComponent<GrowingPlant>().giveLifeToPlant();
                plant.transform.parent = transform;
                plant.gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);
                if(plant.gameObject.GetComponent<GrowingPlant>().occupiedBlock == null)
                    plant.gameObject.GetComponent<GrowingPlant>().occupiedBlock = this;
                plant.SetActive(true);
                return true;
            }
        }
        return false;
    }
}
