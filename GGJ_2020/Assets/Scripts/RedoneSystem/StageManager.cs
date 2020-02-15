using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static int dayCount;

    public delegate void NewDay();
    public static event NewDay OnPlant;
    public static event NewDay OnGrowth;
    public static event NewDay OnSpreadGrass;
    //List of placed spreading plants ready to place new plants
    private static List<List<GrowingPlant>> listSpreading = new List<List<GrowingPlant>>();
    //List of total spreading plants
    private static List<List<GrowingPlant>> listSpreadingTotal = new List<List<GrowingPlant>>();

    private void OnEnable()
    {
        ItemDragHandler.OnClicked += OnNewDay;
    }

    private void OnDisable()
    {
        ItemDragHandler.OnClicked -= OnNewDay;
    }

    private void OnNewDay() {

        if (OnPlant != null) {
            OnPlant();
        }
        if (OnGrowth != null) {
            OnGrowth();
        }
    
        StartCoroutine(OnSpread());

    }

    private IEnumerator OnSpread(float time = 0.5f)
    {
        //Spread grass
        if (OnSpreadGrass != null)
        {
            yield return new WaitForSeconds(time);
            OnSpreadGrass();
        }

        //Spreads flowers 
        ItemDragHandler.isDragReady = false;

        for(int a = listSpreading.Count-1; a >= 0; a--)
        {
            yield return new WaitForSeconds(time);
            for(int p = listSpreading[a].Count - 1; p >= 0; p--)
            {
                listSpreading[a][p].giveSpreadToPlant();
                listSpreading[a].RemoveAt(p);
            }
        }

        ItemDragHandler.isDragReady = true;
        
    }

    public static void AddSpreadingPlant(GrowingPlant plant, int UniqueID)
    {
        for (int l = listSpreadingTotal.Count - 1; l >= 0; l--)
        {
            if (listSpreadingTotal[l].Count == 0)
            {
                listSpreadingTotal[l].Add(plant);
                listSpreading[l].Add(plant);
                return;
            }
            else if (listSpreadingTotal[l][0].uniqueID == UniqueID)
            {
                listSpreadingTotal[l].Add(plant);
                listSpreading[l].Add(plant);
                return;
            }
        }

        listSpreadingTotal.Add(new List<GrowingPlant>());
        listSpreadingTotal[listSpreadingTotal.Count - 1].Add(plant);
        listSpreading.Add(new List<GrowingPlant>());
        listSpreading[listSpreading.Count - 1].Add(plant);
    }

    public static void DisableFlowers(int UniqueID)
    {
        foreach(List<GrowingPlant> plants in listSpreadingTotal)
        {
            if(plants != null) { 
                //Array should have all the same unique ID
                if(plants[0].uniqueID == UniqueID)
                {
                    //Stops script if the flower has already been disabled
                    if (!plants[0].GetComponent<Flower>().spreadEnabled)
                        return;

                    foreach(GrowingPlant plant in plants)
                    {
                        plant.GetComponent<Flower>().spreadEnabled = false;
                    }

                    return;
                }
            }
        }
    }
}
