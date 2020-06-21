using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    public bool levelAccessible = false;
    public bool levelPassed = false;
    public int index = 0;
    public float score = 0f;
    public LevelData(LevelSelection ls) {
        levelAccessible = ls.getLevelAccessible();
        levelPassed = ls.getLevelPassed();
        score = ls.getScore();
        index = ls.getIndex();
    }

    public override string ToString()
    {
        return "Level " + index + ": Accessible = " + levelAccessible + ", Passed = " + levelPassed;
    }

}
