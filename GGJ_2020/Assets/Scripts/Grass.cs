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
    }

    private void OnDisable()
    {
        StageManager.OnPlant -= giveLifeToPlant;
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
    protected override void giveSpreadToPlant()
    {
        if (spreadTime > 0 && currdate < StageManager.dayCount)
        {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            currdate++;
        }
/*        if (Plant.turnAboutToEnd)
        {
            Plant.turnAboutToEnd = false;
            Plant.callForMaint = false;
            Plant.flowersPlanted = false;
            Debug.Log("END DAY " + GrowingPlant.dayCount);
            Plant.dayCount++;
        }*/
    }
}
