using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    IconSwapper iconSwapper;

    private void Start()
    {
        iconSwapper = gameObject.GetComponent<IconSwapper>();
    }

    private void SwapIconCommand(IconSwapper iconSwapper, IconSwappable iconSwappable1, IconSwappable iconSwappable2)
    {
        if (iconSwapper == null)
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
