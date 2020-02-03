using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GrowingPlant
{
    [SerializeField] private Sprite fullyGrown;

    private void Start()
    {
        if (Plant.dayCount == growthStartDate + 2)
            if (fullyGrown != null)
                gameObject.GetComponent<SpriteRenderer>().sprite = fullyGrown;
    }

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
