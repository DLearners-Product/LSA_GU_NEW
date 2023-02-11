using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float zoomIn_value;
    public float zoomOut_value;


    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = new Vector2(zoomIn_value, zoomIn_value);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = new Vector2(zoomOut_value, zoomOut_value);
    }
}