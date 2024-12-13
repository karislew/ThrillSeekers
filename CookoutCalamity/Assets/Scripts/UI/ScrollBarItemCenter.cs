using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScrollBarItemCenter
{
    public static void SnapTo(this ScrollRect scroller, RectTransform child)
    {
        Canvas.ForceUpdateCanvases();

        var contentPos = (Vector2)scroller.transform.InverseTransformPoint(scroller.content.position);
        var childPos = (Vector2)scroller.transform.InverseTransformPoint(child.position);
        var endPos = contentPos - childPos;
        // If no horizontal scroll, then don't change contentPos.x
        if (!scroller.horizontal) endPos.x = contentPos.x;
        // If no vertical scroll, then don't change contentPos.y
        if (!scroller.vertical) endPos.y = contentPos.y;
        scroller.content.anchoredPosition = endPos;
    }
}
