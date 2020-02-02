using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    [SerializeField] public bool spreadOnAdd = false;
    public override void giveLifeToPlant()
    {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        plantID = Structs.id.flower;
        if (occupiedBlock != null)
            occupiedBlock.Place(plantID);
        else
            spreadTime = 2;
        destroyable = false;
    }
    protected override void HandleNewDayUpdate() {
        if (spreadTime > 0) {
            SpreadingPlant sp = gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            spreadTime = 0;
        }
    }
}
