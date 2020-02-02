using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelButton;

    public void ShowNextLevel()
    {
        nextLevelButton.SetActive(true);
    }
}
