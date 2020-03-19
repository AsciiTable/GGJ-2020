using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Plant : MonoBehaviour
{
    public static int dayCount = 0;
    public static bool flowersPlanted;
    public static bool growthNeeds;
    public static bool callForMaint;
    public static bool turnAboutToEnd;
    public GameObject dayCountDisplayer;

    public Action OnDayAdvance;
    public Action PlantStage;
    public Action GrowthStage;
    public Action SpreadStage;

    private void OnEnable()
    {
        UpdateHandler.UpdateOccurred += UpdateOnAdvance;
        dayCountDisplayer = GameObject.FindGameObjectWithTag("dayCounter");
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= UpdateOnAdvance;
    }

    private void UpdateOnAdvance() {
        if (OnDayAdvance != null)
        {
            OnDayAdvance();
            dayCount++;
            dayCountDisplayer.GetComponent<TextMeshPro>().text = "Day " + dayCount;
            Debug.Log("HELLO THIS IS DAYCOUNTER ON DAY " + dayCount);
        }
    }
}