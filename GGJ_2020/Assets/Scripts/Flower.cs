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
        occupiedBlock.Place(plantID);
        destroyable = false;
        this.gameObject.GetComponent<SpreadingPlant>().Spread();
    }
}
