using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ShopCard : MonoBehaviour
{
    [Header("Settings")]
    public int price = 500;
    public string fullDescriptionText = "Меч. Даёт +25 к урону и +10 к силе."; 

    [Header("UI Elements")]
    public Button buyButton;
    public Text coinsText;

    [Header("Details Popup Settings")]
    public GameObject detailPopup;
    public TMP_Text detailText;

    void Update()
    {
        if (coinsText != null && buyButton != null)
        {
            int currentCoins = 0;
            string textValue = coinsText.text;
            textValue = System.Text.RegularExpressions.Regex.Replace(textValue, @"[^\d]", "");

            if (int.TryParse(textValue, out currentCoins))
            {
                if (currentCoins < price)
                {
                    buyButton.interactable = false;
                }
                else
                {
                    buyButton.interactable = true;
                }
            }
        }
    }

    public void OpenDetails()
    {
        if (detailPopup == null) return;

        detailPopup.SetActive(true);
        if (detailText != null) detailText.text = fullDescriptionText;

        detailPopup.transform.localScale = Vector3.zero;
        detailPopup.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }
}
