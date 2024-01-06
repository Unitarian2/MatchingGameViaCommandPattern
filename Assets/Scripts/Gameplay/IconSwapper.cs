using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> horizontalParentObjectList;
    public void Swap(IconSwappable icon1,IconSwappable icon2)
    {
        foreach (GameObject child in horizontalParentObjectList)
        {
            child.transform.GetChild(0).gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
        }

        //Vector3 posIcon1 = icon1.gameObject.transform.position;
        //Vector3 posIcon2 = icon2.gameObject.transform.position;

        //icon1.gameObject.transform.position = posIcon2;
        //icon2.gameObject.transform.position = posIcon1;


        #region SwapHorizontalElements
        //IconSwappable gameobject'inin bir ara parent'ý var horizontal layout grouptan etkilenen bu parent
        Transform icon1HorizontalElement = icon1.gameObject.transform.parent.transform;
        Transform icon2HorizontalElement = icon2.gameObject.transform.parent.transform;

        //Horizontal Layout Group içeren parentlarý al
        Transform parentOfIcon1 = icon1HorizontalElement.parent;
        Transform parentOfIcon2 = icon2HorizontalElement.parent;

        //Child indexlerini bul
        int childIndexOfIcon1 = FindChildIndex(parentOfIcon1, icon1HorizontalElement.gameObject);
        int childIndexOfIcon2 = FindChildIndex(parentOfIcon2, icon2HorizontalElement.gameObject);

        // Icon'larýn parent object'lerini swapla
        icon2HorizontalElement.transform.SetParent(parentOfIcon1);
        icon1HorizontalElement.transform.SetParent(parentOfIcon2);

        // Icon'larýn child index'lerini swapla
        icon2HorizontalElement.transform.SetSiblingIndex(childIndexOfIcon1);
        icon1HorizontalElement.transform.SetSiblingIndex(childIndexOfIcon2);
        #endregion

        foreach (GameObject child in horizontalParentObjectList)
        {
            child.transform.GetChild(0).gameObject.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }


    }

    public bool IsValidSwap(IconSwappable icon1, IconSwappable icon2)
    {
        bool isValid = true;

        return isValid;
    }

    public int FindChildIndex(Transform parent,GameObject targetObject)
    {
        int childIndex = -1;
        int childCount = parent.childCount;

        // Child'ýn index'ini bulmak için parent'ýn childlarýný dönün
        for (int i = 0; i < childCount; i++)
        {
            if (parent.GetChild(i) == targetObject.transform)
            {
                // Ýstenen child bulundu, i deðeri child'ýn index'ini temsil ediyor
                childIndex = i;
                return childIndex;
            }
        }

        return childIndex;
    }

    
}
