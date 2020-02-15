using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;

    private void OnEnable()
    {
        StageManager.OnPlant += giveLifeToPlant;
        StageManager.OnGrowth += giveGrowthToPlant;
        StageManager.OnSpreadGrass += giveSpreadToPlant;
    }
    private void OnDisable()
    {
        StageManager.OnPlant -= giveLifeToPlant;
        StageManager.OnGrowth -= giveGrowthToPlant;
        StageManager.OnSpreadGrass -= giveSpreadToPlant;
    }
    protected override void giveLifeToPlant()
    {
        if (!isPlanted) {
            //occupiedBlock = associatedSeed.GetOccupiedBlock();
            if (occupiedBlock == null)
            {
                Debug.Log("Why don't I have a block yet :<");
            }
            plantID = Structs.id.grass;
            destroyable = false;
            currdate = StageManager.dayCount;
            isPlanted = true;
        }
    }
    public override void giveSpreadToPlant()
    {
        sp = this.gameObject.GetComponent<SpreadingPlant>();
        sp.Spread();
    }
}
