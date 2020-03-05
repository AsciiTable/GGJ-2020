using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SystemSettingsData
{
    public bool fullAccessEnabled;
    public float[] mapScroll;
    public SystemSettingsData() {
        fullAccessEnabled = SaveSystem.fullAccessMode;
/*        mapScroll[0] = SaveSystem.mapScroll.x;
        mapScroll[1] = SaveSystem.mapScroll.y;
        mapScroll[2] = SaveSystem.mapScroll.z;*/
    }
}
