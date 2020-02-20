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
    [SerializeField] protected int buttonIndex = 0;

    private Seed[] seeds;
    private GameObject[] blocks;
    private MenuManager menuManager;

    [Header("Animation")]
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Sprite winBackground;
    [SerializeField] private Sprite winSprite;

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
        if ((CheckSeedless() && !gameEnded) || (treeDied && !gameEnded))
        {
            gameEnded = true;

            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(0.5f);

        if (CheckPlants() && !treeDied)
        {
            StartCoroutine(Win());
            // level Data update
            if (buttonIndex > 0) {
                SaveSystem.levelData[buttonIndex - 1].levelPassed = true;
                if (buttonIndex < SaveSystem.levelData.Length) {
                    SaveSystem.levelData[buttonIndex].levelAccessible = true;
                }
            }
                

/*            int index = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.IndexOf(" ")));
            SaveSystem.levelData = SaveSystem.getAllLevels();
            if (SaveSystem.levelData.Length > index)
            {
                SaveSystem.levelData[index].levelPassed = true;
                if (SaveSystem.levelData.Length > index + 1)
                    SaveSystem.levelData[index + 1].levelAccessible = true;
                else
                    Debug.Log("Index too large for level accessible update.");
            }
            else
                Debug.Log("Index too large for level pass update.");
            
            SaveSystem.SaveLevels(SaveSystem.levelData);*/
        }
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
        foreach(Block block in FindObjectsOfType<Block>())
        {
            if (block.gameObject.activeInHierarchy && !block.GetComponent<Block>().content)
                return false;
        }

        return true;
    }

    private IEnumerator Win()
    {
        WinAnimation();

        yield return new WaitForSeconds(1);

        FindObjectOfType<ButtonManager>().ShowNextLevel();
        menuManager.CloseMenus();
        menuManager.OpenMenu(winScreenIndex);
    }

    private void Lose()
    {
        menuManager.CloseMenus();
        menuManager.OpenMenu(loseScreenIndex);
    }
    private void WinAnimation()
    {
        background.sprite = winBackground;

        foreach(Block block in FindObjectsOfType<Block>())
        {
            block.gameObject.GetComponent<SpriteRenderer>().sprite = winSprite;
        }
    }
}
