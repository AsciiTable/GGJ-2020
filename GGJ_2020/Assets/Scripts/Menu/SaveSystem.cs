using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    public static LevelData[] levelData;
    public static SystemSettingsData systemSettingsData;
    public static bool fullAccessMode = false;
    public static int completedLevelCount;
    public static int totalLevelCount;
/*    public static Vector3 mapScroll;*/
    public static LevelData[] getAllLevels() {
        GameObject map = GameObject.Find("/Canvas/MapContainer/Map");
        if (map != null)
        {
            int levelCount = map.transform.childCount;
            LevelData[] ld = new LevelData[levelCount];
            completedLevelCount = 0;
            totalLevelCount = levelCount;
            for (int i = 0; i < levelCount; i++) {
                LevelData ild = new LevelData(map.transform.GetChild(i).gameObject.GetComponent<LevelSelection>());
                Debug.Log("Loaded " + ild.ToString());
                ld[i] = ild;
            }
            return ld;
        }
        else {
            Debug.LogError("No \"Map\" GameObject found in this scene.");
            return null;
        }
    }

    public static void SaveLevels(LevelData[] levels) {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levels.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, levels);
        stream.Close();
    }

    public static void SaveSystemSettings(SystemSettingsData ssd) {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/systemSettings.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, ssd);
        stream.Close();
    }

    public static LevelData[] LoadLevels() {
        string path = Application.persistentDataPath + "/levels.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData[] ld = bf.Deserialize(stream) as LevelData[];
            stream.Close();
            levelData = ld;
            return ld;
        }
        else {
            Debug.LogError("Level Data save file not found.");
            return null;
        }
    }
    public static SystemSettingsData LoadSystemSettings()
    {
        string path = Application.persistentDataPath + "/systemSettings.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            systemSettingsData = bf.Deserialize(stream) as SystemSettingsData;
            stream.Close();
            fullAccessMode = systemSettingsData.fullAccessEnabled;
/*            mapScroll.x = systemSettingsData.mapScroll[0];
            mapScroll.y = systemSettingsData.mapScroll[1];
            mapScroll.z = systemSettingsData.mapScroll[2];*/
            return systemSettingsData;
        }
        else
        {
            Debug.LogError("System Settings save file not found.");
            return null;
        }
    }
    public static void UpdateThisLevel(int index, float score, bool accessible, bool passed) {
        if (index > 0) {
            levelData[index - 1].score = score;
            levelData[index - 1].levelAccessible = accessible;
            levelData[index - 1].levelPassed = passed;
        }
        SaveLevels(levelData);
    }

    public static void EnableFullAccessMode() {
        for (int i = 0; i < SaveSystem.levelData.Length; i++) {
            levelData[i].levelAccessible = true;
        }
        fullAccessMode = true;
        if (systemSettingsData == null)
            systemSettingsData = new SystemSettingsData();
        systemSettingsData.fullAccessEnabled = true;
/*        GameObject map = GameObject.Find("/Canvas/MapContainer/Map");
        mapScroll = map.gameObject.GetComponent<RectTransform>().transform.position;
        systemSettingsData.mapScroll[0] = mapScroll.x;
        systemSettingsData.mapScroll[1] = mapScroll.y;
        systemSettingsData.mapScroll[2] = mapScroll.z;*/
        SaveLevels(levelData);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveSystemSettings(systemSettingsData);
    }
    public static void DisableFullAccessMode()
    {
        bool foundend = false;
        for (int i = 0; i < SaveSystem.levelData.Length; i++)
        {
            if (!levelData[i].levelPassed)
                levelData[i].levelAccessible = false;
            else if (levelData[i].levelPassed && foundend) {
                levelData[i].levelAccessible = false;
                //levelData[i].levelPassed = false; // erases win data
            }

            if (!foundend) {
                if ((i-1) >= 0 && levelData[i - 1].levelPassed && !levelData[i].levelPassed) {
                    levelData[i].levelAccessible = true;
                    foundend = true;
                }
            }
        }
        fullAccessMode = false;
        if (systemSettingsData == null)
            systemSettingsData = new SystemSettingsData();
        systemSettingsData.fullAccessEnabled = false;
        GameObject map = GameObject.Find("/Canvas/MapContainer/Map");
/*        mapScroll = map.gameObject.GetComponent<RectTransform>().transform.position;
        systemSettingsData.mapScroll[0] = mapScroll.x;
        systemSettingsData.mapScroll[1] = mapScroll.y;
        systemSettingsData.mapScroll[2] = mapScroll.z;*/
        SaveLevels(levelData);
        LoadLevels();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveSystemSettings(systemSettingsData);
    }
}
