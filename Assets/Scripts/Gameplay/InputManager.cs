using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    IconSwapper iconSwapper;

    IconSwappable firstSelectedIcon;
    IconSwappable secondSelectedIcon;

    [SerializeField] private GameObject parentObject;

    private void Start()
    {
        iconSwapper = gameObject.GetComponent<IconSwapper>();
        firstSelectedIcon = null; secondSelectedIcon = null;

        


        //Gameboard'daki buttonlarý çek
        Button[] buttons = parentObject.GetComponentsInChildren<Button>(true);

        // Her bir buton için onClick olayýný dinle
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button.gameObject));
            
        }
    }

    
    private void OnButtonClick(GameObject clickedObject)
    {
        Debug.LogWarning("Clicked Object" + clickedObject.name + " / " + clickedObject.GetInstanceID());
        
        if (firstSelectedIcon == null)
        {
            firstSelectedIcon = clickedObject.GetComponent<IconSwappable>();
            firstSelectedIcon.ToggleSelection();
        }
        else if(secondSelectedIcon == null)
        {
            secondSelectedIcon = clickedObject.GetComponent<IconSwappable>();
            SwapIconCommand(iconSwapper, firstSelectedIcon,secondSelectedIcon);
            firstSelectedIcon.ToggleSelection();
            firstSelectedIcon = null; secondSelectedIcon = null;
        }
    }

    private void SwapIconCommand(IconSwapper iconSwapper, IconSwappable iconSwappable1, IconSwappable iconSwappable2)
    {
        //Herhangi biri null ise çalýþtýrmýyoruz.
        if (iconSwapper == null || iconSwappable1 == null || iconSwappable2 == null)
        {
            return;
        }
        if (iconSwapper.IsValidSwap(iconSwappable1, iconSwappable2))
        {
            ICommand command = new SwapCommand(iconSwapper, iconSwappable1, iconSwappable2);
            CommandInvoker.ExecuteCommand(command);
        }
    }
}
