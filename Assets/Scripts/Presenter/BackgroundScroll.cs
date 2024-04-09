using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage _background;
    [SerializeField] private float _x, _y;

    public void moveBG()
    {
        _background.uvRect = new Rect(_background.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _background.uvRect.size);
    }
}
