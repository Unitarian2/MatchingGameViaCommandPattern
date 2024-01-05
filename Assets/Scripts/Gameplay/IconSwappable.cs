using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwappable : MonoBehaviour
{
    int iconIndex;
    Sprite unselectedImage;
    Sprite selectedImage;
    bool isSelected = false;

    public void ToggleSelection()
    {
        if (isSelected)
        {
            gameObject.GetComponent<Image>().sprite = unselectedImage;
            isSelected = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = selectedImage;
            isSelected = true;
        }
    }

    public void SetupIconElement(int iconIndex,Sprite unselectedImage, Sprite selectedImage)
    {
        this.iconIndex = iconIndex;
        this.unselectedImage = unselectedImage;
        this.selectedImage = selectedImage;
    }
}
