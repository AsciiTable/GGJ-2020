using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullAccessMode : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.GetComponent<Toggle>().isOn = SaveSystem.fullAccessMode;
    }
    public void ToggleFullAccessMode() {
        if (this.gameObject.GetComponent<Toggle>().isOn && !SaveSystem.fullAccessMode)
            SaveSystem.EnableFullAccessMode();
        else if(!this.gameObject.GetComponent<Toggle>().isOn && SaveSystem.fullAccessMode)
            SaveSystem.DisableFullAccessMode();
    }
}
