using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //ID of next initialized spreading plant
    private static int nextPlantID = 0;
    public static int getNextPlantID
    {
        get
        {
            nextPlantID++;
            return nextPlantID - 1;
        }
    }

    [Header("Plant Info")]
    public bool content = false;
    public bool occupied = false;
    [Tooltip("Plant growing on this block")]
    public Structs.id occupiedPlant = Structs.id.empty;
    public int uniqueID = -1;

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
            Place(Structs.id.grass, true);
            content = true;
        }
        return true;
    }

    public bool Place(Structs.id seed, bool OG, int plantID = -1, bool buffer = false)
    {
        if (occupied) {
            return false;
        }
            
        occupied = true;
        occupiedPlant = seed;

        PlantPooler[] pools = FindObjectsOfType<PlantPooler>();
        foreach (PlantPooler pool in pools)
        {
            if (seed == pool.ID)
            {
                GameObject plant = pool.GetObject();
                if (plant.gameObject.GetComponent<GrowingPlant>().occupiedBlock == null)
                {
                    plant.gameObject.GetComponent<GrowingPlant>().occupiedBlock = this.gameObject.GetComponent<Block>();
                }
                plant.gameObject.GetComponent<GrowingPlant>().isOriginal = OG;

                //Gets a new plantID if none is given
                uniqueID = (plantID == -1) ? getNextPlantID : plantID;
                plant.GetComponent<GrowingPlant>().uniqueID = uniqueID;

                //plant.GetComponent<GrowingPlant>().giveLifeToPlant();
                plant.transform.parent = transform;
                plant.gameObject.transform.localPosition = new Vector3(0f, 0f, -1f);

                //Adds flower to list
                if(plant.GetComponent<GrowingPlant>().plantID == Structs.id.flower) {
                    StageManager.AddSpreadingPlant(plant.GetComponent<GrowingPlant>(), plant.GetComponent<GrowingPlant>().uniqueID);

                    //Has the flower not spread first turn if buffer is true
                    if (buffer)
                        plant.gameObject.GetComponent<GrowingPlant>().setSpreadTime = 0;
                }

                plant.SetActive(true);

                return true;
            }
        }
        return false;
    }

    public void DisableFlowers()
    {
        GridManager gm = GetComponentInParent<GridManager>();

        GetComponent<BoxCollider2D>().enabled = false;
        int? fUp = checkFlowerID(Vector2.up, (gm.BlockHeight + gm.BorderHeight) / 2);
        int? fRight = checkFlowerID(Vector2.right, (gm.BlockWidth + gm.BorderWidth) / 2);
        int? fDown = checkFlowerID(Vector2.down, (gm.BlockHeight + gm.BorderHeight) / 2);
        int? fLeft = checkFlowerID(Vector2.left, (gm.BlockWidth + gm.BorderWidth) / 2);

        if (fUp.HasValue) {
            StageManager.DisableFlowers(fUp.Value);
        }
        if (fRight.HasValue) {
            StageManager.DisableFlowers(fRight.Value);
        }
        if (fDown.HasValue) {
            StageManager.DisableFlowers(fDown.Value);
        }
        if (fLeft.HasValue) {
            StageManager.DisableFlowers(fLeft.Value);
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

    protected int? checkFlowerID(Vector2 direction, float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.5f);
        if (hit.collider != null && hit.collider.CompareTag("Block"))
        {
            Block b = hit.transform.gameObject.GetComponent<Block>();
            if (b != null)
            {
                if (b.occupiedPlant == Structs.id.flower && uniqueID != b.uniqueID)
                {
                    if (b.GetComponentInChildren<Flower>() != null)
                        return b.uniqueID;
                }
            }
        }
        return null;
    }
}
