using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public void SceneSelector(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void GameObjectToggleOn(GameObject o) {
        o.SetActive(true);
    }

    public void GameObjectToggleOff(GameObject o) {
        o.SetActive(false);
    }
}
