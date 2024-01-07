using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.Rendering.VolumeComponent;

public class SuccessValidationHandler
{
    private List<IconSwappable> board;
    private IconSwappable[,] boardMatrix;

    public SuccessValidationHandler(List<IconSwappable> board)
    {
        this.board = board;
        Init(board.Count);
    }

    private void Init(int count)
    {
        boardMatrix = new IconSwappable[count/4, count/4]; 
    }

    public bool IsValidSwap(IconSwappable icon1, IconSwappable icon2)
    {
        bool isValid = false;

        //Icon'lar�n listedeki konumunu buluyoruz
        int indexA = board.IndexOf(icon1);
        int indexB = board.IndexOf(icon2);

        //icon'lar�n listedeki yerini swapl�yoruz sanki yer de�i�mi� gibi
        (board[indexB], board[indexA]) = (board[indexA], board[indexB]);

        //Board matrix'ini olu�turuyoruz.
        FillBoardMatrix();

        //Swap edilecek olan iki icon'dan herhangi biri patlama olu�turacaksa isValid true'dur.
        isValid = CheckAdjacentElements(icon1) || CheckAdjacentElements(icon2);

        return isValid;
    }

    private bool CheckAdjacentElements(IconSwappable icon)
    {
        int rows = boardMatrix.GetLength(0);
        int cols = boardMatrix.GetLength(1);
        bool found = false;


        for (int i = 0; i < rows; i++)
        {
            if (found) break;

            for (int j = 0; j < cols; j++)
            {
                if (boardMatrix[i, j] == icon)
                {
                    //A�a��daki kontrol etti�imiz eleman�n kuzey,g�ney,do�u,bat� eleman� ile(varsa) iconIndex'i e�it mi diye kontrol ediyoruz.
                    if (i - 1 >= 0)
                    {
                        if (boardMatrix[i - 1, j].IconIndex == icon.IconIndex)
                        {
                            return true;
                        }   
                    }
                    if (i + 1 <= rows - 1)
                    {
                        if (boardMatrix[i + 1, j].IconIndex == icon.IconIndex)
                        {
                            return true;
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (boardMatrix[i, j - 1].IconIndex == icon.IconIndex)
                        {
                            return true;
                        }
                    }
                    if (j + 1 <= cols - 1)
                    {
                        if (boardMatrix[i, j + 1].IconIndex == icon.IconIndex)
                        {
                            return true;
                        }
                    }
                    break;
                }
            }
        }
        return false;

    }

    private void FillBoardMatrix()
    {
        int listIndex = 0;

        for (int i = 0; i < boardMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < boardMatrix.GetLength(1); j++)
            {
                boardMatrix[i, j] = board[listIndex];
                listIndex++;
            }
        }
    }
}
