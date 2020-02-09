using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlant : MonoBehaviour
{
    [HideInInspector] public Block occupiedBlock;
    [HideInInspector] public bool isOriginal = false;
    [SerializeField] protected string plantName = "";
    [SerializeField] protected int growTime = 2;
    [SerializeField] protected int spreadTime= 0;
    [SerializeField] protected bool destroyable = true;
    [SerializeField] public Seed associatedSeed;
    protected bool isPlanted = false;
    public Structs.id plantID = Structs.id.empty;
    protected int age = 0;
    protected int growthStartDate;

    public Block getOBlock() {
        return occupiedBlock;
    }

    private void OnEnable()
    {
        StageManager.OnPlant += giveLifeToPlant;
        StageManager.OnGrowth += giveGrowthToPlant;
        StageManager.OnSpread += giveSpreadToPlant;
    }

    private void OnDisable()
    {
        StageManager.OnPlant -= giveLifeToPlant;
        StageManager.OnGrowth -= giveGrowthToPlant;
        StageManager.OnSpread -= giveSpreadToPlant;
    }

    /*    protected override void HandleNewDayUpdate()
        {
            if (Plant.growthNeeds && destroyable) {
                Debug.Log("Checking " + plantID +" growth");
                checkGrowth();
                Plant.growthNeeds = false;
                Plant.callForMaint = true;
            }
        }*/

    protected virtual void giveLifeToPlant() {
        if (!isPlanted) {
            occupiedBlock = associatedSeed.GetOccupiedBlock();
            if (occupiedBlock == null) {
                Debug.Log("Why don't I have a block yet :<");
            }
            growthStartDate = StageManager.dayCount;
            age = 0;
            isPlanted = true;
        }
    }

    protected virtual void giveGrowthToPlant() {
        age++;
        if (destroyable)
            checkGrowth();
    }

    protected virtual void giveSpreadToPlant()
    {
        // By default, do nothing
    }

    public virtual void checkGrowth() {
        if (age == growTime)
        {
            Debug.Log(plantID + " fully grown");
            destroyable = false;
            occupiedBlock.content = true;
        }
    }

    public bool getDestroyable() {
        return destroyable;
    }
}
