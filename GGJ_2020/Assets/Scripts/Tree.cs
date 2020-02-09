using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GrowingPlant
{
    [SerializeField] private Sprite fullyGrown;

    protected override void giveLifeToPlant()
    {
        if (!isPlanted)
        {
            age = 0;
            occupiedBlock = associatedSeed.GetOccupiedBlock();
            if (occupiedBlock == null)
            {
                Debug.Log("Why don't I have a block yet :<");
            }
            growthStartDate = StageManager.dayCount;
            plantID = Structs.id.tree;
            occupiedBlock.Place(plantID, false);
            destroyable = true;
            isPlanted = true;
        }
    }
    protected override void giveGrowthToPlant()
    {
        age++;
        Debug.Log("Tree at age " + age);
        if (destroyable)
            checkGrowth();
            if(!destroyable && fullyGrown != null)
                gameObject.GetComponent<SpriteRenderer>().sprite = fullyGrown;
    }
}
