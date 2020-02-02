using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private bool gameEnded = false;
    [SerializeField] private int loseScreenIndex = 2;
    [SerializeField] private int winScreenIndex = 3;

    private Seed[] seeds;
    private GameObject[] blocks;
    private MenuManager menuManager;

    private void OnEnable()
    {
        seeds = FindObjectsOfType<Seed>();
        blocks = FindObjectOfType<BlockPooler>().GetPool().ToArray();
        menuManager = FindObjectOfType<MenuManager>();

        UpdateHandler.UpdateOccurred += CheckLevel;
    }
    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= CheckLevel;
    }

    private void CheckLevel()
    {
        if (CheckSeedless())
        {
            gameEnded = true;

            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(0.5f);

        if (CheckPlants())
            Win();
        else
            Lose();
    }

    //Return true if there are no more plants
    private bool CheckSeedless()
    {
        foreach(Seed seed in seeds)
        {
            if (!seed.hasSeeds)
                return false;
        }

        if (seeds.Length == 0)
        {
            Debug.Log("Seeds variable is empty");
            return false;
        }

        return true;
    }

    private bool CheckPlants()
    {
        foreach(GameObject block in blocks)
        {
            if (block.activeInHierarchy && !block.GetComponent<Block>().content)
                return false;
        }

        if (blocks.Length == 0)
        {
            Debug.Log("Seeds variable is empty");
            return false;
        }

        return true;
    }

    private void Win()
    {
        FindObjectOfType<ButtonManager>().ShowNextLevel();
        menuManager.CloseMenus();
        menuManager.OpenMenu(winScreenIndex);
    }

    private void Lose()
    {
        menuManager.CloseMenus();
        menuManager.OpenMenu(loseScreenIndex);
    }
}
