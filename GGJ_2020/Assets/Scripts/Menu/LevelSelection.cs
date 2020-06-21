using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LevelSelection : SceneSelection
{
    [SerializeField] protected bool levelAccessible = false;
    [SerializeField] protected bool levelPassed = false;
    [SerializeField] protected float score = 0f;
    [SerializeField] protected int index = -1;
    [SerializeField] private bool isAutoAccessible = false;
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private Sprite passedSprite;
    private void Start()
    {
        LoadLevel();
        if (isAutoAccessible && !levelAccessible) {
            levelAccessible = true;
            SaveLevel();
        }
    }

    public void SaveLevel() {
        // currently saves and overrides everything
        // will change as more content is added for efficiency 
        SaveSystem.UpdateThisLevel(index, score, levelAccessible, levelPassed);
    }

    public void LoadLevel() {
        Image img = this.gameObject.GetComponent<Image>();
        if (SaveSystem.levelData == null) 
            return;
        LevelData ld = SaveSystem.levelData[index-1];
        levelAccessible = ld.levelAccessible;
        if (isAutoAccessible) {
            levelAccessible = true;
        }
        levelPassed = ld.levelPassed;
        score = ld.score;
        //index = ld.index;

        if (!levelAccessible)
        {
            img.sprite = lockedSprite;
            img.color = new Color(195, 195, 195);
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else if(!levelAccessible && !levelPassed)
        {
            img.sprite = unlockedSprite;
            img.color = new Color(255, 255, 255);
            this.gameObject.GetComponent<Button>().interactable = true;
        }

        if (levelPassed) {
            Debug.Log("Level is passed. Display passed sprite.");
            img.sprite = passedSprite;
            LevelLoader.UpdateProgressionText();
        }

            
        Debug.Log("Loading Level " + index + ": " + levelAccessible + ", " + levelPassed);
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
