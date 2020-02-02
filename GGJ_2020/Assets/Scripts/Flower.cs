using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    [SerializeField] private bool isOriginal = false;
    private SpreadingPlant sp;
    public override void giveLifeToPlant()
    {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        plantID = Structs.id.flower;
        occupiedBlock.Place(plantID);
        destroyable = false;
        sp = this.GetComponent<SpreadingPlant>();
        sp.bOccupied = occupiedBlock;
        if (isOriginal) {
            sp.Spread();
        }
    }
}
