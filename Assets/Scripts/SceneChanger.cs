using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 0.5f;
    public bool fadeOutOnStart = false;

    void Start()
    {
        if (fadeCanvasGroup == null) return;

        if (fadeOutOnStart)
        {
            fadeCanvasGroup.alpha = 1f;
            fadeCanvasGroup.gameObject.SetActive(true);
            fadeCanvasGroup.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                fadeCanvasGroup.gameObject.SetActive(false);
            });
        }
        else
        {
            fadeCanvasGroup.alpha = 0f;
            fadeCanvasGroup.gameObject.SetActive(false);
        }
    }

        public void ChangeScene(string sceneName)
    {
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.gameObject.SetActive(true); 
            
            fadeCanvasGroup.DOFade(1f, fadeDuration).OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
