using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;
    private bool firstSpread = true;
    public override void giveLifeToPlant()
    {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        plantID = Structs.id.flower;
        destroyable = false;
        currdate = Plant.dayCount;
    }
    protected override void HandleNewDayUpdate() {
        if (spreadTime > 0 && currdate < Plant.dayCount)
        {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            currdate++;
        }
    }
}
