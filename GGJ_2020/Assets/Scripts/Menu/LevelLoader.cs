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
        if (SaveSystem.LoadLevels() == null) {
            SaveSystem.levelData = SaveSystem.getAllLevels();
            SaveSystem.SaveLevels(SaveSystem.levelData);
        }
        else
            SaveSystem.levelData = SaveSystem.LoadLevels();
        foreach (LevelData l in SaveSystem.levelData)
            Debug.Log(l.ToString());
        DontDestroyOnLoad(this.gameObject);
    }
}
