using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public static int dayCount;
    private int compareDate;
    public Button nextDayButton;
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
        Debug.Log("Heard!!");
        if (OnDayAdvance != null) {
            OnDayAdvance();
        }
            
    }
}
