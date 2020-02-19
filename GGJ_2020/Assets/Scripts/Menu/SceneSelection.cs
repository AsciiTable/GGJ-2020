using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public void Start()
    {
        SaveSystem.getAllLevels();
    }
    public void SceneSelector(string scene) {
        SceneManager.LoadScene(scene);
    }
    
}
