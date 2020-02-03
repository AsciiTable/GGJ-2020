using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlant : DayHandler
{
    [SerializeField] protected string plantName = "";
    [SerializeField] protected int growTime = 2;
    [SerializeField] protected int spreadTime= 0;
    [SerializeField] protected bool destroyable = true;
    [SerializeField] public Seed associatedSeed;
    public Structs.id plantID = Structs.id.empty;
    private int age = 0;
    //[HideInInspector]public Block occupiedBlock;
    protected int growthStartDate;
    protected int dayOfGrowth;

    public Block getOBlock() {
        return occupiedBlock;
    }
    protected override void HandleNewDayUpdate()
    {
        if (Plant.growthNeeds && destroyable) {
            Debug.Log("Checking " + plantID +" growth");
            checkGrowth();
            Plant.growthNeeds = false;
            Plant.callForMaint = true;
        }
    }

    public virtual void giveLifeToPlant() {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
        age = 1;
    }

    public virtual void checkGrowth() {
        if (age >= growTime)
        {
            Debug.Log(plantID + " fully grown");
            destroyable = false;
            occupiedBlock.content = true;
        }
        else
            age++;
    }

    public bool getDestroyable() {
        return destroyable;
    }
}
