using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    [SerializeField] private bool isOriginal = false;
    private SpreadingPlant sp;
    public override void giveLifeToPlant()
    {
        sp = this.GetComponent<SpreadingPlant>();
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        plantID = Structs.id.flower;
        occupiedBlock.Place(plantID);
        destroyable = false;
        if (isOriginal) {
            sp.Spread();
        }
    }
}
