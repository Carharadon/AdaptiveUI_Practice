using UnityEngine;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    [Header("Настройки товара")]
    public int price = 150;
    public string fullDescriptionText = "Меч. Даёт +25 к урону и +10 к силе."; 

    [Header("Ссылки на элементы карточки")]
    public Button buyButton;

    [Header("Ссылки на всплывающее окно деталей")]
    public GameObject detailPopup;
    public Text detailText;

    void Update()
    {
        GameHUD hud = Object.FindFirstObjectByType<GameHUD>();

        if (hud != null)
        {
            if (hud.coins >= price)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

    public void OpenDetails()
    {
        detailPopup.SetActive(true);

        detailText.text = fullDescriptionText;
    }
}
