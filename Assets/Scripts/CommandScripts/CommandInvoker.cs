using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class CommandInvoker
{
    private static List<ICommand> undoStack = new List<ICommand>();
    public static void ExecuteCommand(ICommand command)
    {
        undoStack.Add(command);
        if (undoStack.Count > 10)
        {
            undoStack.RemoveAt(0);
        }

        command.Execute();   
    }
    public static void UndoCommand()
    {
        if (undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Last();
            undoStack.Remove(activeCommand);
            activeCommand.Undo();
        }
    }
    
    public static List<ICommand> GetICommandHistory()
    {
        return undoStack;
    }
    public static ICommand GetLastExecutedCommand()
    {
        return undoStack.LastOrDefault();
    }
}
