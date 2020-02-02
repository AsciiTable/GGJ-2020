using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlant : DayHandler
{
    [SerializeField] protected string plantName;
    [SerializeField] protected int growTime;
    [SerializeField] protected int spreadTime;
    [SerializeField] protected bool destroyable;
    [SerializeField] public Seed associatedSeed;
    public Structs.id plantID = Structs.id.empty;
   
    protected Block occupiedBlock;
    protected int growthStartDate;

    protected int dayOfGrowth;
    protected override void HandleNewDayUpdate()
    {
        Debug.Log("Growing Plant Subscribed!");
        checkGrowth();
    }

    public virtual void giveLifeToPlant() {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
    }

    public virtual void checkGrowth() {
        if (Plant.dayCount - growthStartDate >= this.growTime)
        {
            Debug.Log("Plant fully grown");
            destroyable = false;
        }
    }
}
