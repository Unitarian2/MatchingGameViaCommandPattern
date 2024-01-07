using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<IconSwappable> iconElementsList;
    [SerializeField] private List<IconSwappableSO> iconElementsSoList;

    private void Start()
    {
        SetupBoard();
    }

    private void SetupBoard()
    {
        Init();
        FillElementData();
        InitializeElements();

    }

    private void InitializeElements()
    {
        foreach (var iconElement in iconElementsList)
        {
            iconElement.InitializeIconElement();
        }
    }

    private void FillElementData()
    {
        GameBoardSetupManager gameBoardSetupManager = new GameBoardSetupManager(iconElementsList, iconElementsSoList);
        List<IconSwappable> generatedIconElementsList = gameBoardSetupManager.SetupGameBoardData();
        for (int i = 0; i < iconElementsList.Count; i++)
        {
            iconElementsList[i].SetupIconElement(generatedIconElementsList[i].IconIndex, generatedIconElementsList[i].UnselectedImage, generatedIconElementsList[i].SelectedImage);
        }
    }

    

    private void Init()
    {
        foreach (var iconElement in iconElementsList)
        {
            iconElement.InitIconElement();
        }
    }

    public void StartGameProcess()
    {

    }

    public List<IconSwappable> GetIconElementsList()
    {
        return iconElementsList;
    }


}
