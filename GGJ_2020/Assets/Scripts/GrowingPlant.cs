using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrowingPlant : DayHandler
{
    [SerializeField] protected string plantName;
    [SerializeField] protected int growTime;
    [SerializeField] protected int spreadTime;
    [SerializeField] protected bool destroyable;
    protected Block occupiedBlock;
    protected int growthStartDate;

    protected int dayOfGrowth;
    // Start is called before the first frame update
    void Start()
    {
        occupiedBlock = gameObject.GetComponentInParent<Block>();
        growthStartDate = Plant.dayCount;
    }

    protected override void HandleNewDayUpdate()
    {
        Debug.Log("Growing Plant Subscribed!");
    }


}
