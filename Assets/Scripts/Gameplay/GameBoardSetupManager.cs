using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardSetupManager
{
    private List<IconSwappable> iconElementsList;
    private List<IconSwappableSO> iconElementsSoList;
    public GameBoardSetupManager(List<IconSwappable> iconElementsList, List<IconSwappableSO> iconElementsSoList)
    {
        this.iconElementsList = iconElementsList;
        this.iconElementsSoList = iconElementsSoList;
    }

    public List<IconSwappable> SetupGameBoardData()
    {
        foreach (var iconElement in iconElementsList)
        {
            IconSwappableSO selectedIcon = GetRandomIconSwappableSO();
            iconElement.SetupIconElement(selectedIcon.iconIndex, selectedIcon.unselectedImage, selectedIcon.selectedImage);
        }

        return iconElementsList;
    }

    private IconSwappableSO GetRandomIconSwappableSO()
    {
        return iconElementsSoList[UnityEngine.Random.Range(0, iconElementsSoList.Count)];
    }

}
