using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    IconSwapper iconSwapper;

    IconSwappable firstSelectedIcon;
    IconSwappable secondSelectedIcon;

    private void Start()
    {
        iconSwapper = gameObject.GetComponent<IconSwapper>();
        firstSelectedIcon = null; secondSelectedIcon = null;
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
