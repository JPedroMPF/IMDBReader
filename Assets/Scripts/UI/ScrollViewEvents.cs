using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewEvents : MonoBehaviour
{
    [Range(0,1)]
    public float bottomSensitive = 0.025f;

    ScrollRect scrollRect;
    public bool trackScroll = false;
    public delegate void ScrollReachBottom();
    public static event ScrollReachBottom onScrollEnd;

    private void Start()
    {
        scrollRect = transform.GetComponent<ScrollRect>();
    }

    private void Update()
    {
        if (scrollRect.normalizedPosition.y < 0.025f && trackScroll)
        {
            onScrollEnd?.Invoke();          
        }
    }   
}
