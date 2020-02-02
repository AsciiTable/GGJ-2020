using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;
    private bool init = true;
    public override void giveLifeToPlant()
    {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        plantID = Structs.id.flower;
        destroyable = false;
        currdate = Plant.dayCount;
        spreadTime = 1;
        if (occupiedBlock != null)
            occupiedBlock.content = true;
    }
    protected override void HandleNewDayUpdate() {
        if (Plant.flowersPlanted) {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            Plant.flowersPlanted = false;
            Plant.growthNeeds = true;
        }
        if (!Plant.flowersPlanted && spreadTime > 0 && currdate < Plant.dayCount)
        {
            Debug.Log("Maint Occured on " + Plant.dayCount);
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            currdate++;
        }
        if (!Plant.flowersPlanted && Plant.callForMaint) {
            Plant.callForMaint = false;
            Plant.turnAboutToEnd = true;
        }
    }
}
