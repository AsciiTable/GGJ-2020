using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : SceneSelection
{
    [SerializeField] protected bool levelAccessible = false;
    [SerializeField] protected bool levelPassed = false;
    [SerializeField] protected float score = 0f;
    [SerializeField] protected int index = -1;
    [SerializeField] private bool isAutoAccessible = false;
    private void Start()
    {
        if (isAutoAccessible && !levelAccessible) {
            levelAccessible = true;
            SaveLevel();
        }
        LoadLevel();
        Debug.Log("Index " + index + " loaded");
    }

    public void SaveLevel() {
        // currently saves and overrides everything
        // will change as more content is added for efficiency 
        SaveSystem.UpdateThisLevel(index, score, levelAccessible, levelPassed);
    }

    public void LoadLevel() {
        //SaveSystem.levelData = SaveSystem.LoadLevels();
        LevelData ld = SaveSystem.levelData[index-1];
        levelAccessible = ld.levelAccessible;
        levelPassed = ld.levelPassed;
        score = ld.score;
        index = ld.index;

        if (levelPassed)
            Debug.Log("Level is passed. Display passed sprite.");
        if (!levelAccessible)
            // In the future, set the button active to false and change the sprite
            this.gameObject.SetActive(false);
    }
    public bool getLevelAccessible() {
        return levelAccessible;
    }
    public void setLevelAccessible(bool tf) {
        levelAccessible = tf;
    }
    public bool getLevelPassed()
    {
        return levelPassed;
    }
    public void setLevelPassed(bool tf)
    {
        levelPassed = tf;
    }
    public float getScore()
    {
        return score;
    }
    public void setScore(float sc)
    {
        score = sc;
    }
    public int getIndex()
    {
        return index;
    }
    public void setIndex(int i)
    {
        index = i;
    }
}
