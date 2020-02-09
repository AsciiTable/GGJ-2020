using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static int dayCount;

    public delegate void NewDay();
    public static event NewDay OnPlant;
    public static event NewDay OnGrowth;
    public static event NewDay OnSpread;

    private void OnEnable()
    {
        UpdateHandler.UpdateOccurred += OnNewDay;
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= OnNewDay;
    }

    private void OnNewDay() {
        if (OnPlant != null) {
            OnPlant();
        }
        if (OnGrowth != null) {
            OnGrowth();
        }
        if (OnSpread != null) {
            OnSpread();
        }
    }
}
