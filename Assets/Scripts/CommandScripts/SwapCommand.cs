using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCommand : ICommand
{
    IconSwapper swapper;
    IconSwappable iconSwappable1;
    IconSwappable iconSwappable2;

    public SwapCommand(IconSwapper swapper, IconSwappable iconSwappable1, IconSwappable iconSwappable2)
    {
        this.swapper = swapper;
        this.iconSwappable1 = iconSwappable1;
        this.iconSwappable2 = iconSwappable2;
    }

    public void Execute()
    {
        swapper.Swap(iconSwappable1, iconSwappable2, false);
    }

    public void Redo()
    {
        swapper.Swap(iconSwappable1, iconSwappable2, false);
    }

    public void Undo()
    {
        swapper.Swap(iconSwappable2, iconSwappable1, true);
    }
}
