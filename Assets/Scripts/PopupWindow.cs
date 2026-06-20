using UnityEngine;
using DG.Tweening; 

public class PopupWindow : MonoBehaviour
{
    public float duration = 0.2f;

    public void OpenWindow()
    {
        gameObject.SetActive(true);

        transform.localScale = Vector3.zero;

        transform.DOScale(1.1f, duration).OnComplete(() =>
        {
            transform.DOScale(1.0f, duration / 2f);
        });
    }

    public void CloseWindow()
    {
        transform.DOScale(0f, duration).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}