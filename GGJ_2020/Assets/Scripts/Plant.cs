using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public static int dayCount;
    public Button nextDayButton;
    public Action OnDayAdvance;

    private void Start()
    {
        nextDayButton.onClick.AddListener(UpdateOnAdvance);
    }

/*    private void OnEnable()
    {
        UpdateHandler.UpdateOccurred += UpdateOnAdvance;
        Debug.Log("From Plant");
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= UpdateOnAdvance;
        Debug.Log("Disable From Plant");
    }*/

    private void UpdateOnAdvance() {
        Debug.Log("Heard!!");
        if (OnDayAdvance != null) {
            OnDayAdvance();
            dayCount++;
            Debug.Log("Day Advances: " + dayCount);
        }
            
    }
}
