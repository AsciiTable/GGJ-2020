using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public static int dayCount;
    public static bool flowersPlanted;
    public static bool growthNeeds;
    public static bool callForMaint;
    public static bool turnAboutToEnd;

    public Action OnDayAdvance;

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