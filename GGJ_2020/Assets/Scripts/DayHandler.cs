using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DayHandler : MonoBehaviour
{
    public Plant daySubscriber;

    public void OnEnable()
    {
        if (daySubscriber == null) {
            daySubscriber = GetComponent<Plant>();
            Debug.Log("From Day");
        }
        daySubscriber.OnDayAdvance += HandleNewDayUpdate;
    }

    private void OnDisable()
    {
        daySubscriber.OnDayAdvance -= HandleNewDayUpdate;
    }

    protected abstract void HandleNewDayUpdate();
    
}
