using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IconSwappableSO", menuName = "ScriptableObjects/IconSwappable", order = 1)]
public class IconSwappableSO : ScriptableObject
{
    public int iconIndex;
    public Sprite unselectedImage;
    public Sprite selectedImage;
    
}
