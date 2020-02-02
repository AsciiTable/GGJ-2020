using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GrowingPlant
{
    public override void giveLifeToPlant()
    {
        growTime = 1;
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
        plantID = Structs.id.tree;
        occupiedBlock.Place(plantID, false);
        destroyable = true;
    }
}
