using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewEvents : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{    
    public RectTransform contentRect;

    public delegate void Scrolling(float scrollAmount, ScrollDirection direction);
    public static event Scrolling onScrolling;

    private float begginingStartPos = 0.0f;


    public void OnBeginDrag(PointerEventData eventData)
    {
        begginingStartPos = Mathf.Round(contentRect.localPosition.y*100f)/100f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var current = Mathf.Round(contentRect.localPosition.y * 100f) / 100f;
        var distanceTraveled = Mathf.Abs(current - begginingStartPos); 

        //CHECK DIRECTION
        if (current > begginingStartPos)
        {
            onScrolling?.Invoke(distanceTraveled,ScrollDirection.Down);
        }

        if (current < begginingStartPos)
        {
            onScrolling?.Invoke(distanceTraveled, ScrollDirection.Up);
        }

        begginingStartPos = current;

    }

    public void UpdatePosition(float removedItemsHeight,ScrollDirection direction)
    {
        float finalNewPos;
        if (direction == ScrollDirection.Down)
        {
            finalNewPos = contentRect.localPosition.y - removedItemsHeight;
        }
        else
        {
            finalNewPos = contentRect.localPosition.y + removedItemsHeight;
        }

        contentRect.localPosition = new Vector3(0, finalNewPos, 0);
    }
        
}

public enum ScrollDirection
{
    Up,
    Down,
}