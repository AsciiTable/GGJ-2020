using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private MenuManager pops;

    private void Start()
    {
        pops = GetComponentInParent<MenuManager>();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ChangeScene(string sceneName )
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeMenus(int index)
    {
        if (pops.Menus - 1 >= index && index >= 0)
        {
            pops.CloseMenus();
            pops.OpenMenu(index);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
