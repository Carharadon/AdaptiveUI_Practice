using UnityEngine;
using UnityEngine.EventSystems; 
using DG.Tweening;

public class UIButtonHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Sizes")]
    public float normalScale = 1.0f;
    public float hoverScale = 1.15f;
    public float clickScale = 0.85f;
    public float duration = 0.15f;

    [Header("Audio")]
    public AudioClip clickSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(hoverScale, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(normalScale, duration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOScale(clickScale, duration / 2f).OnComplete(() =>
        {
            transform.DOScale(hoverScale, duration / 2f);
        });

        if (clickSound != null)
        {
            AudioManager audioManager = Object.FindFirstObjectByType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.PlaySFX(clickSound);
            }
        }
    }
}
