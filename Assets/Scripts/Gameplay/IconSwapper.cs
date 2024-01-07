using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IconSwapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> horizontalParentObjectList;

    bool isSwapping;
    bool isUndoSwap;

    public void Swap(IconSwappable icon1,IconSwappable icon2,bool isUndoSwap)
    {
        this.isUndoSwap = isUndoSwap;
        StartCoroutine(SwapPosition(icon1, icon2));
    }

    IEnumerator SwapPosition(IconSwappable icon1, IconSwappable icon2)
    {
        float duration = 0.5f;
        isSwapping = true;

        Vector2 startPosObject1 = icon1.gameObject.transform.position;
        Vector2 startPosObject2 = icon2.gameObject.transform.position;

        Vector2 icon1AnchoredPos = icon1.gameObject.GetComponent<RectTransform>().anchoredPosition;
        Vector2 icon2AnchoredPos = icon2.gameObject.GetComponent<RectTransform>().anchoredPosition;

        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            icon1.gameObject.transform.position = Vector2.Lerp(startPosObject1, startPosObject2, t);
            icon2.gameObject.transform.position = Vector2.Lerp(startPosObject2, startPosObject1, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ��lem bitti�inde pozisyonlar� tekrar do�ru yerle�tir
        icon1.gameObject.transform.position = startPosObject2;
        icon2.gameObject.transform.position = startPosObject1;

        isSwapping = false;

        SwapLayoutPosition(icon1, icon2, icon1AnchoredPos, icon2AnchoredPos);
    }

    private void SwapLayoutPosition(IconSwappable icon1, IconSwappable icon2, Vector2 icon1AnchoredPos, Vector2 icon2AnchoredPos)
    {
        //De�i�imi yapmadan �nce de�i�im sonunda patlama olacak m� onun bilgisini sakl�yoruz. Undo yap�lm�� bir Swap yap�rsak her t�rl� true olmal� yoksa geriye do�ru gitmeye ba�l�yoruz.
        bool isValidSwap = IsValidSwap(icon1, icon2) || isUndoSwap;

        foreach (GameObject child in horizontalParentObjectList)
        {
            child.transform.GetChild(0).gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
        }

        #region SwapHorizontalElements
        //IconSwappable gameobject'inin bir ara parent'� var horizontal layout grouptan etkilenen bu parent
        Transform icon1HorizontalElement = icon1.gameObject.transform.parent.transform;
        Transform icon2HorizontalElement = icon2.gameObject.transform.parent.transform;

        //Horizontal Layout Group i�eren parentlar� al
        Transform parentOfIcon1 = icon1HorizontalElement.parent;
        Transform parentOfIcon2 = icon2HorizontalElement.parent;

        //Child indexlerini bul
        int childIndexOfIcon1 = FindChildIndex(parentOfIcon1, icon1HorizontalElement.gameObject);
        int childIndexOfIcon2 = FindChildIndex(parentOfIcon2, icon2HorizontalElement.gameObject);

        // Icon'lar�n parent object'lerini swapla
        icon2HorizontalElement.transform.SetParent(parentOfIcon1);
        icon1HorizontalElement.transform.SetParent(parentOfIcon2);

        // Icon'lar�n child index'lerini swapla
        icon2HorizontalElement.transform.SetSiblingIndex(childIndexOfIcon1);
        icon1HorizontalElement.transform.SetSiblingIndex(childIndexOfIcon2);
        #endregion

        foreach (GameObject child in horizontalParentObjectList)
        {
            child.transform.GetChild(0).gameObject.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }

        icon1.gameObject.GetComponent<RectTransform>().anchoredPosition = icon1AnchoredPos;
        icon2.gameObject.GetComponent<RectTransform>().anchoredPosition = icon2AnchoredPos;

        //Patlama olmayacaksa hi� beklemeden Undo yap�yoruz.
        if (!isValidSwap)
        {
            CommandInvoker.UndoCommand();
        }
        else
        {
            //Oyunun patlamalara ba�lamas� i�in gameManager'da state de�i�iyoruz.
            GameManager.Instance.StartGameValidationProcess();
        }

    }

    public bool IsValidSwap(IconSwappable icon1, IconSwappable icon2)
    {
        SuccessValidationHandler successValidationHandler = new SuccessValidationHandler(GameManager.Instance.GetIconElementsList());

        return successValidationHandler.IsValidSwap(icon1, icon2);
    }

    public int FindChildIndex(Transform parent,GameObject targetObject)
    {
        int childIndex = -1;
        int childCount = parent.childCount;

        // Child'�n index'ini bulmak i�in parent'�n childlar�n� d�n�n
        for (int i = 0; i < childCount; i++)
        {
            if (parent.GetChild(i) == targetObject.transform)
            {
                // �stenen child bulundu, i de�eri child'�n index'ini temsil ediyor
                childIndex = i;
                return childIndex;
            }
        }

        return childIndex;
    }

    
}
