using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GrowingPlant
{
    public override void giveLifeToPlant()
    {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
        plantID = Structs.id.tree;
        occupiedBlock.Place(plantID);
    }

    protected override void HandleNewDayUpdate()
    {
        checkGrowth();
    }
}
