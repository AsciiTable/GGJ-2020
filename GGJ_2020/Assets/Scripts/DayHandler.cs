using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayHandler : MonoBehaviour
{
    public Plant daySubscriber;
    [HideInInspector] public Block occupiedBlock;
    public bool isOriginal = false;
    public void OnEnable()
    {
        if (daySubscriber == null) {
            daySubscriber = GetComponent<Plant>();
        }
        daySubscriber.OnDayAdvance += HandleNewDayUpdate;
    }

    private void OnDisable()
    {
        daySubscriber.OnDayAdvance -= HandleNewDayUpdate;
    }

    protected abstract void HandleNewDayUpdate();
    
}
