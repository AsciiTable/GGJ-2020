using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ButtonListener : MonoBehaviour
{
    public Button nextDayButton;

    // Start is called before the first frame update
    void Start()
    {
        nextDayButton = this.GetComponent<Button>();
        nextDayButton.onClick.AddListener(UpdateOnAdvanceButton);
    }

    private void UpdateOnAdvanceButton()
    {
        Plant.dayCount++;
        Debug.Log("Day Advances: " + Plant.dayCount);
    }
}
