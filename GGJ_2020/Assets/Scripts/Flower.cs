using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : GrowingPlant
{
    private SpreadingPlant sp;
    public static int currdate;
    private bool wait = false;
    private bool planted = false;

    //Block stops all flowers with same id when disabling this
    public bool spreadEnabled = true;
    

    private void OnEnable()
    {
        if (!isPlanted) {
            StageManager.OnPlant += giveLifeToPlant;
            wait = true;
            spreadEnabled = true;
        }
        StageManager.OnGrowth += giveGrowthToPlant;
    }

    private void Update()
    {
        if (wait == true)
        {
            wait = false;
        }
        else if(!wait && spreadTime > 0 && !planted)
        {
            //StageManager.OnSpread += giveSpreadToPlant;
            StageManager.AddSpreadingPlant(GetComponent<Flower>(), uniqueID);
            planted = true;
        }
    }

    private void OnDisable()
    {
        StageManager.OnPlant -= giveLifeToPlant;
        StageManager.OnGrowth -= giveGrowthToPlant;
        //StageManager.OnSpread -= giveSpreadToPlant;
    }

    protected override void giveLifeToPlant()
    {
        if (!isPlanted)
        {
            Debug.Log("Live you thing!");
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
            spreadTime = 1;

            if (isOriginal)
            {
                sp = this.gameObject.GetComponent<SpreadingPlant>();
                sp.Spread(true);
                Debug.Log("OG spread");
                //Flower.currdate = StageManager.dayCount;
                spreadTime = 0;
            }

            isPlanted = true;
        }
    }
    public override void giveSpreadToPlant() {
        Debug.Log("Spread boy: " + spreadTime);
        if (spreadTime > 0 && spreadEnabled) {
            sp = this.gameObject.GetComponent<SpreadingPlant>();
            sp.Spread();
            Debug.Log("Non og spread");
            spreadTime = 0;
        }
    }

}
