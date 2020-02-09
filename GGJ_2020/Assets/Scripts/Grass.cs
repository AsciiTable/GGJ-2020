using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;

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
    protected override void giveSpreadToPlant()
    {
        sp = this.gameObject.GetComponent<SpreadingPlant>();
        sp.Spread();
        spreadTime = 0;
        currdate++;
    }
}
