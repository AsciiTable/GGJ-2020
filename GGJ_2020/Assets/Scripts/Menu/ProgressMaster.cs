using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressMaster : MonoBehaviour
{
    void Awake()
    {
        SaveSystem.completedLevelCount = 0;
    }
}
