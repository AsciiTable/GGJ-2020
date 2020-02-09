﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    private SpreadingPlant sp;
    public static int currdate;
    private bool wait = false;
    [SerializeField] private int initAgeToSpread = 2;

    private void OnEnable()
    {
        if (!isPlanted) {
            StageManager.OnPlant += giveLifeToPlant;
            wait = true;
        }
        StageManager.OnGrowth += giveGrowthToPlant;
    }

    private void Update()
    {
        if (wait == true)
        {
            wait = false;
        }
        else
            StageManager.OnSpread += giveSpreadToPlant;
    }

    private void OnDisable()
    {
        StageManager.OnPlant -= giveLifeToPlant;
        StageManager.OnGrowth -= giveGrowthToPlant;
        StageManager.OnSpread -= giveSpreadToPlant;
    }

    protected override void giveLifeToPlant()
    {
        if (!isPlanted)
        {
            //occupiedBlock = associatedSeed.GetOccupiedBlock();
            if (occupiedBlock == null)
            {
                Debug.Log("Why don't I have a block yet :<");
            }
            plantID = Structs.id.flower;
            destroyable = false;
            currdate = StageManager.dayCount;
            //spreadTime = 1;
            if (occupiedBlock != null)
                occupiedBlock.content = true;
            age = 0;
            if (isOriginal)
            {
                sp = this.gameObject.GetComponent<SpreadingPlant>();
                sp.Spread();
                Debug.Log("OG spread");
                //Flower.currdate = StageManager.dayCount;
            }
            isPlanted = true;
        }
    }
    protected override void giveSpreadToPlant() {
        sp = this.gameObject.GetComponent<SpreadingPlant>();
        sp.Spread();
        Debug.Log("Non og spread");
    }
}
