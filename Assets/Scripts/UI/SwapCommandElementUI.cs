using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapCommandElementUI : MonoBehaviour
{
    [SerializeField] private Image icon1;
    [SerializeField] private Image icon2;
    public void UpdateData(Sprite icon1,Sprite icon2)
    {
        this.icon1.sprite = icon1;
        this.icon2.sprite = icon2;
    }
}
