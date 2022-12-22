using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHover : MonoBehaviour
{
    Vector2 baseSize = new Vector2(50, 50);

    public void OnHover(RectTransform rect) => rect.sizeDelta = new Vector2(baseSize.x + 5, baseSize.y + 5);

    public void OnExit(RectTransform rect) => rect.sizeDelta = baseSize;

}
