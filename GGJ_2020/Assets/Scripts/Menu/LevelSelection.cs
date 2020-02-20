using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : SceneSelection
{
    protected bool levelAccessible = false;
    protected bool levelPassed = false;
    protected float score = 0f;
    protected int index = -1;
    [SerializeField] private bool isAutoAccessible = false;
    private void OnEnable()
    {
        if (isAutoAccessible) 
            levelAccessible = true;
    }

    public void SaveLevel() {
        // currently saves and overrides everything
        // will change as more content is added for efficiency 
        SaveSystem.SaveLevels(SaveSystem.levelData);
    }

    public void LoadLevel() {
        SaveSystem.levelData = SaveSystem.LoadLevels();
        LevelData ld = SaveSystem.levelData[index];
        levelAccessible = ld.levelAccessible;
        levelPassed = ld.levelPassed;
        score = ld.score;
        index = ld.index;
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
