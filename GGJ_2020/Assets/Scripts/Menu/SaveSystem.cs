using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static LevelData[] levelData;
    public static LevelData[] getAllLevels() {
        GameObject map = GameObject.Find("/Canvas/MapContainer/Map");
        if (map != null)
        {
            int levelCount = map.transform.childCount;
            LevelData[] ld = new LevelData[levelCount];
            Debug.Log("There are " + levelCount + " levels.");
            for (int i = 0; i < levelCount; i++) {
                //map.transform.GetChild(i).gameObject.GetComponent<LevelSelection>().setIndex(i);
                LevelData ild = new LevelData(map.transform.GetChild(i).gameObject.GetComponent<LevelSelection>());
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
        for (int i = 0; i < levels.Length; i++) {
            bf.Serialize(stream, levels[i]);
        }
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
            Debug.LogError("Save file not found.");
            return null;
        }
    }
    public static void UpdateThisLevel(int index, int score, bool accessible, bool passed) {
        if (index > 0) {
            levelData[index - 1].score = score;
            levelData[index - 1].levelAccessible = accessible;
            levelData[index - 1].levelPassed = passed;
        } 
    }
}
