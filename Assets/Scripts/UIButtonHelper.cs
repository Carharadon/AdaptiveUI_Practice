using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;
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

    private Button mainButton;

    void Awake()
    {
        mainButton = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mainButton != null && !mainButton.interactable) return;
        
        transform.DOScale(hoverScale, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (mainButton != null && !mainButton.interactable) return;
        
        transform.DOScale(normalScale, duration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mainButton != null && !mainButton.interactable) return;

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
