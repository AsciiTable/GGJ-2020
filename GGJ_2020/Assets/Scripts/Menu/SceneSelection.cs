using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    //public string scene;
    public void SceneSelector(string scene) {
        SceneManager.LoadScene(scene);
    }
}
