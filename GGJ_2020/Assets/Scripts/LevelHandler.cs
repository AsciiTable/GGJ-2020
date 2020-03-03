using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public bool treeDied = false;

    [SerializeField] private bool gameEnded = false;
    [SerializeField] private int loseScreenIndex = 2;
    [SerializeField] private int winScreenIndex = 3;
    [SerializeField] protected int buttonIndex = 1;

    private Seed[] seeds;
    private GameObject[] blocks;
    private MenuManager menuManager;

    [Header("Animation")]
    [SerializeField] private GameObject loseBackground = null;
    [SerializeField] private GameObject winBackground = null;
    [SerializeField] private Camera camera;
    [SerializeField] private Color loseColor = Color.gray;
    [SerializeField] private Color winColor = Color.cyan;

    private void OnEnable()
    {
        seeds = FindObjectsOfType<Seed>();
        blocks = FindObjectOfType<BlockPooler>().GetPool().ToArray();
        menuManager = FindObjectOfType<MenuManager>();
        camera = FindObjectOfType<Camera>();
        Time.timeScale = 1;
        UpdateHandler.UpdateOccurred += CheckLevel;
    }
    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= CheckLevel;
    }

    private void Start()
    {
        loseBackground.SetActive(true);
        winBackground.SetActive(false);
        camera.backgroundColor = loseColor;
    }

    private void CheckLevel()
    {
        if ((CheckSeedless() && !gameEnded) || (treeDied && !gameEnded))
        {
            gameEnded = true;

            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitUntil(() => !StageManager.flowerGrowing);

        Debug.Log("Game Win?: " + (CheckPlants() && !treeDied));
        StageManager.dayCount = 0;
        if (CheckPlants() && !treeDied)
        {
            // level Data update
            if (buttonIndex > 0)
            {
                int b = buttonIndex - 1;
                SaveSystem.levelData[b].levelPassed = true;
                Debug.Log("Level Passed = " + SaveSystem.levelData[b].levelPassed);
                if (buttonIndex < SaveSystem.levelData.Length)
                {
                    SaveSystem.levelData[buttonIndex].levelAccessible = true;
                }
                SaveSystem.SaveLevels(SaveSystem.levelData);
            }
            StartCoroutine(Win());
        }
        else
            Lose();

        Debug.Log("Game Win?: " + (CheckPlants() && !treeDied));
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
        foreach(Block block in FindObjectsOfType<Block>())
        {
            if (block.gameObject.activeInHierarchy && !block.GetComponent<Block>().content)
                return false;
        }

        return true;
    }

    private IEnumerator Win()
    {
        yield return StartCoroutine(WinAnimation());
        FindObjectOfType<ButtonManager>().ShowNextLevel();
        menuManager.CloseMenus();
        menuManager.OpenMenu(winScreenIndex);
    }

    private void Lose()
    {
        /*
        menuManager.CloseMenus();
        menuManager.OpenMenu(loseScreenIndex);
        */
    }
    private IEnumerator WinAnimation()
    {
        yield return new WaitForSeconds(1);
        camera.backgroundColor = winColor;
        yield return new WaitForSeconds(1);
        winBackground.SetActive(true);
        loseBackground.SetActive(false);
        yield return new WaitForSeconds(1);
    }
}
