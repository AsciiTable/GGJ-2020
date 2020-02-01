using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : GrowingPlant
{
    protected override void HandleNewDayUpdate()
    {
        Debug.Log("Tree Subscribed!");
        if (Plant.dayCount - growthStartDate >= this.growTime) {
            Debug.Log("Tree fully grown");
        }
    }

}
