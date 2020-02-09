using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;
    private bool init = true;
    [SerializeField]private int ageToStartSpreading = 2;
    protected override void giveLifeToPlant()
    {
        if (!isPlanted) {
            occupiedBlock = associatedSeed.GetOccupiedBlock();
            if (occupiedBlock == null)
            {
                Debug.Log("Why don't I have a block yet :<");
            }
            plantID = Structs.id.flower;
            destroyable = false;
            currdate = StageManager.dayCount;
            spreadTime = 1;
            if (occupiedBlock != null)
                occupiedBlock.content = true;
            isPlanted = true;
        }

    }
    protected override void giveSpreadToPlant() {
        if (age < ageToStartSpreading) {
            return;
        }
        if (spreadTime > 0) {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
        }
        else if (spreadTime > 0 && currdate < StageManager.dayCount)
        {
            Debug.Log("Maint Occured on " + StageManager.dayCount);
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            currdate++;
        }
    }
}
