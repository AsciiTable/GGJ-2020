﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int initialMenu;
    [SerializeField] private Canvas[] menus;
    [SerializeField] private bool openOnStart = true;

    private void Start()
    {
        CloseMenus();
        if (openOnStart)
            menus[initialMenu].gameObject.SetActive(true);
    }

    public void CloseMenus() 
    { 
        foreach(Canvas menu in menus)
        {
            menu.gameObject.SetActive(false);
        }
    }
    public void OpenMenu(int index)
    {
        if (menus.Length > index)
            menus[index].gameObject.SetActive(true);
    }
}