using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCommand : ICommand
{
    public IconSwapper Swapper {get; private set;}
    public IconSwappable IconSwappable1 { get; private set; }
    public IconSwappable IconSwappable2 { get; private set; }
    public HistoryUIHandler HistoryUIHandler { get; private set; }

    public SwapCommand(HistoryUIHandler historyUIHandler, IconSwapper swapper, IconSwappable iconSwappable1, IconSwappable iconSwappable2)
    {
        this.Swapper = swapper;
        this.IconSwappable1 = iconSwappable1;
        this.IconSwappable2 = iconSwappable2;
        this.HistoryUIHandler = historyUIHandler;
    }

    public void Execute()
    {
        Swapper.Swap(IconSwappable1, IconSwappable2, false);
        HistoryUIHandler.UpdateHistoryUI(false);
    }

    public void Redo()
    {
        Swapper.Swap(IconSwappable1, IconSwappable2, false);
        HistoryUIHandler.UpdateHistoryUI(false);
    }

    public void Undo()
    {
        Swapper.Swap(IconSwappable2, IconSwappable1, true);
        HistoryUIHandler.UpdateHistoryUI(true);
    }
}
