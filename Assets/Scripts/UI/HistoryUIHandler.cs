using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject historyPanel;
    GameObject commandUiElement;
    private void Start()
    {
        commandUiElement = Resources.Load<GameObject>("SwapCommandPanel");//Spawn edilecek gameobject load'luyoruz
    }
    public void UpdateHistoryUI(bool isRemoval)
    {
        //Undo yapılmış
        if (isRemoval)
        {
            Destroy(historyPanel.transform.GetChild(historyPanel.transform.childCount - 1).gameObject);
        }
        //Execute yapılmış
        else
        {
            ICommand command = CommandInvoker.GetLastExecutedCommand();
            if(command != null)
            {
                if (command is SwapCommand swapCommand)
                {
                    Sprite iconSwappable1Sprite = swapCommand.IconSwappable1.gameObject.GetComponent<Image>().sprite;
                    Sprite iconSwappable2Sprite = swapCommand.IconSwappable2.gameObject.GetComponent<Image>().sprite;
                    GameObject spawnedCommandElement = Instantiate(commandUiElement, historyPanel.transform);

                    spawnedCommandElement.GetComponent<SwapCommandElementUI>().UpdateData(iconSwappable1Sprite, iconSwappable2Sprite);
                }
            }
            
        }

        //Ekrandan taşmaması için 8'den fazla olan element'i siliyoruz.
        if(historyPanel.transform.childCount > 8)
        {
            Destroy(historyPanel.transform.GetChild(0).gameObject);
        }

    }

    public void ClearCommandHistoryPanel()
    {
        foreach (Transform child in historyPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
