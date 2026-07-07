using UnityEngine;
using TMPro;

public class NotificationTimer : MonoBehaviour
{
    public float repeatRate = 10f;       
    public float hideDelay = 3f;         

    public GameObject notificationPanel;
    public TMP_Text shortDescText;       

    [TextArea(3, 5)]
    public string fullDescription = "Внимание! На склад завезли новый тактический дробовик. Успей купить в магазине со скидкой 15 процентов!";

    void Start()
    {
        if (notificationPanel != null)
        {
            notificationPanel.SetActive(false);
        }

        InvokeRepeating("ShowNotification", 2f, repeatRate);
    }

    void ShowNotification()
    {
        if (notificationPanel == null) return;

        if (shortDescText != null)
        {
            if (fullDescription.Length > 40)
            {
                shortDescText.text = fullDescription.Substring(0, 37) + "...";
            }
            else
            {
                shortDescText.text = fullDescription;
            }
        }

        notificationPanel.SetActive(true);

        CancelInvoke("HideNotification");
        Invoke("HideNotification", hideDelay);
    }

    void HideNotification()
    {
        if (notificationPanel != null)
        {
            notificationPanel.SetActive(false);
        }
    }
}
