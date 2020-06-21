using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static TextMeshProUGUI progression;
    public void Awake()
    {
        progression = GameObject.FindGameObjectWithTag("ProgressChecker").GetComponent<TextMeshProUGUI>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelLoader");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        GameObject Tog = GameObject.FindGameObjectWithTag("FullAccess");
        SystemSettingsData ssd = SaveSystem.LoadSystemSettings();
        if (ssd == null) {
/*            GameObject map = GameObject.Find("/Canvas/MapContainer/Map");
            SaveSystem.mapScroll = map.gameObject.GetComponent<RectTransform>().transform.position;*/
            ssd = new SystemSettingsData();
        }
        Tog.gameObject.GetComponent<Toggle>().isOn = ssd.fullAccessEnabled;
        LevelData[] temp = SaveSystem.LoadLevels();
        SaveSystem.getAllLevels();
        if (temp == null)
        {
            SaveSystem.levelData = SaveSystem.getAllLevels();
            SaveSystem.SaveLevels(SaveSystem.levelData);
        }
        else if (temp.Length > SaveSystem.levelData.Length)
        {
            LevelData[] temp2 = SaveSystem.levelData;
            SaveSystem.levelData = new LevelData[temp.Length];
            for (int i = 0; i < SaveSystem.levelData.Length; i++) {
                for (int j = 0; j < temp2.Length; j++) {
                    if (temp[i].index == temp2[j].index) {
                        SaveSystem.levelData[i] = temp2[j];
                        break;
                    }
                }
                SaveSystem.levelData[i] = temp[i];
            }
        }
        else
            SaveSystem.levelData = temp;
        /*        foreach (LevelData l in SaveSystem.levelData)
                    Debug.Log(l.ToString());*/

        progression.SetText(SaveSystem.completedLevelCount + "/" + SaveSystem.totalLevelCount);
        DontDestroyOnLoad(this.gameObject);
    }

    public static void UpdateProgressionText() {
        SaveSystem.completedLevelCount++;
        progression.SetText(SaveSystem.completedLevelCount + "/" + SaveSystem.totalLevelCount);
    }
}
