using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Plant : MonoBehaviour
{
    [SerializeField] protected string plantName;
    [SerializeField] protected int growthTime;
    [SerializeField] protected int spreadTime;
    [SerializeField] protected bool destroyable;
    protected Block occupiedBlock;
}
