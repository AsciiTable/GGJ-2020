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
    //[HideInInspector]public Block occupiedBlock;
    protected int growthStartDate;
    protected int dayOfGrowth;

    public Block getOBlock() {
        return occupiedBlock;
    }
    protected override void HandleNewDayUpdate()
    {
        if (Plant.growthNeeds) {
            if (growTime > 0) {
                growTime--;
            }
            if (growTime == 0 && destroyable) {
                destroyable = false;
                Debug.Log(plantName + " fully grown.");
            }
            Plant.growthNeeds = false;
            Plant.callForMaint = true;
        }
    }

    public virtual void giveLifeToPlant() {
        occupiedBlock = associatedSeed.GetOccupiedBlock();
        growthStartDate = Plant.dayCount;
    }

    public bool getDestroyable() {
        return destroyable;
    }
}
