using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SystemSettingsData
{
    public bool fullAccessEnabled;
    public SystemSettingsData() {
        fullAccessEnabled = SaveSystem.fullAccessMode;
    }
}
