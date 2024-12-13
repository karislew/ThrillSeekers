using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollBarNavigation : MonoBehaviour, ISelectHandler
{

    private ScrollRect scrollRect;
    private float scrollPosition = 1;
    private RectTransform target;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponentInParent<ScrollRect>(true);
        target = (RectTransform)this.transform;

        int childCount = scrollRect.content.transform.childCount - 1;
        int childIndex = transform.GetSiblingIndex();

        childIndex = childIndex < ((float)childCount / 2f) ? childIndex - 1 : childIndex;

        scrollPosition = 1 - ((float)childIndex / childCount);

        
    }
    Vector3 LocalPositionWithinAncestor(Transform ancestor, Transform target)
    {
        var result = Vector3.zero;
        while (ancestor != target && target != null)
        {
            result += target.localPosition;
            target = target.parent;
        }
        return result;
    }
    public void EnsureScrollVisible()
    {
        Canvas.ForceUpdateCanvases();

        var targetPosition = LocalPositionWithinAncestor(scrollRect.content, target);
        var top = (-targetPosition.y) - target.rect.height / 2;
        var bottom = (-targetPosition.y) + target.rect.height / 2;

        var topMargin = 100; // this is here because there are headers over the buttons sometimes

        var result = scrollRect.content.anchoredPosition;
        if (result.y > top - topMargin)
            result.y = top - topMargin;
        if (result.y + scrollRect.viewport.rect.height < bottom)
            result.y = bottom - scrollRect.viewport.rect.height;

        //Debug.Log($"{targetPosition} {target.rect.size} {top} {bottom} {scrollRect.content.anchoredPosition}->{result}");

        scrollRect.content.anchoredPosition = result;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (scrollRect)
        {
            scrollRect.verticalScrollbar.value = scrollPosition;
        }

        if (scrollRect != null)
            EnsureScrollVisible();

        // below is not used, but was default.
        //throw new System.NotImplementedException();
    }


}
