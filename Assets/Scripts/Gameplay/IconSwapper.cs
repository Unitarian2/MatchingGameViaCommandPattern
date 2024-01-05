using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSwapper : MonoBehaviour
{
    public void Swap(IconSwappable icon1,IconSwappable icon2)
    {
        Vector3 posIcon1 = icon1.gameObject.transform.position;
        Vector3 posIcon2 = icon2.gameObject.transform.position;

        icon1.gameObject.transform.position = posIcon2;
        icon2.gameObject.transform.position = posIcon1;
    }

    public bool IsValidSwap(IconSwappable icon1, IconSwappable icon2)
    {
        bool isValid = false;

        return isValid;
    }
}
