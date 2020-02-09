using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;
    protected override void giveLifeToPlant()
    {
        plantID = Structs.id.grass;
        destroyable = false;
        currdate = StageManager.dayCount;
    }
    protected override void HandleNewDayUpdate()
    {
        if (spreadTime > 0 && currdate < Plant.dayCount)
        {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
            currdate++;
        }
        if (Plant.turnAboutToEnd)
        {
            Plant.turnAboutToEnd = false;
            Plant.callForMaint = false;
            Plant.flowersPlanted = false;
            Debug.Log("END DAY " + GrowingPlant.dayCount);
            Plant.dayCount++;
        }
    }
}
