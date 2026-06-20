using UnityEngine;
using UnityEngine.EventSystems; 

public class DragWindow : MonoBehaviour, IDragHandler
{
    public RectTransform windowTransform;

    public void OnDrag(PointerEventData eventData)
    {
        if (windowTransform != null)
        {
            windowTransform.anchoredPosition += eventData.delta;
        }
    }
}
