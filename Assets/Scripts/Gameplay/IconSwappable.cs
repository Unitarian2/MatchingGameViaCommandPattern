using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSwappable : MonoBehaviour
{
    public int IconIndex { get; private set; }
    public Sprite UnselectedImage { get; private set; }
    public Sprite SelectedImage { get; private set; }
    bool isSelected = false;

    public void ToggleSelection()
    {
        if (isSelected)
        {
            gameObject.GetComponent<Image>().sprite = UnselectedImage;
            isSelected = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = SelectedImage;
            isSelected = true;
        }
    }

    public void SetupIconElement(int iconIndex,Sprite unselectedImage, Sprite selectedImage)
    {
        this.IconIndex = iconIndex;
        this.UnselectedImage = unselectedImage;
        this.SelectedImage = selectedImage;
    }

    public void InitializeIconElement()
    {
        gameObject.GetComponent<Image>().sprite = UnselectedImage;
        isSelected = false;
    }

    public void InitIconElement()
    {
        this.IconIndex = -1;
    }
}
