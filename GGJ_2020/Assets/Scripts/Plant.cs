using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public static int dayCount = 0;
    public static bool turnAboutToEnd = false;
    public static bool callForMaint = false;
    public static bool growthNeeds = false;
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