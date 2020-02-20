using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LevelLoader");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        LevelData[] temp = SaveSystem.LoadLevels();
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
        DontDestroyOnLoad(this.gameObject);
    }
}
