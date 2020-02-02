using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : GrowingPlant
{
    private SpreadingPlant sp;
    private int currdate;
    public override void giveLifeToPlant()
    {
        plantID = Structs.id.grass;
        destroyable = false;
        currdate = Plant.dayCount;
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
            Debug.Log("END DAY " + Plant.dayCount);
            Plant.dayCount++;
            Debug.Log("START DAY " + Plant.dayCount);
        }
    }
}
