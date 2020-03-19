using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Plant : MonoBehaviour
{
    //public static int dayCount = 0;
    public static bool flowersPlanted;
    public static bool growthNeeds;
    public static bool callForMaint;
    public static bool turnAboutToEnd;
    

    public Action OnDayAdvance;
    public Action PlantStage;
    public Action GrowthStage;
    public Action SpreadStage;

    private void OnEnable()
    {
        UpdateHandler.UpdateOccurred += UpdateOnAdvance;
        
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= UpdateOnAdvance;
    }

    private void UpdateOnAdvance() {
        if (OnDayAdvance != null)
        {
            OnDayAdvance();
        }
    }
}