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
    [HideInInspector] public int age;
    public Structs.id plantID = Structs.id.empty;
    //[HideInInspector]public Block occupiedBlock;
    protected int growthStartDate;
    protected int dayOfGrowth;

    public Block getOBlock() {
        return occupiedBlock;
    }
    protected override void HandleNewDayUpdate()
    {
        if (age <= (growTime)) {
            Debug.Log("Checking " + plantID +" growth");
            checkGrowth();
            age++;
        }
    }

    public virtual void giveLifeToPlant() {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
        age = 0;
    }

    public virtual void checkGrowth() {
        if (Plant.dayCount - growthStartDate > this.growTime && destroyable)
        {
            Debug.Log(plantID + " fully grown");
            destroyable = false;
        }
    }

    public bool getDestroyable() {
        return destroyable;
    }
}
