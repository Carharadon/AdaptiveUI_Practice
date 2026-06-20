using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public GameObject notificationPanel;
    public Text descriptionText;
    public GameObject popupWindow;

    public float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            ShowNotification();
            timer = 0f;
        }

        if (notificationPanel.activeSelf && Input.GetMouseButtonDown(1))
        {
            CloseNotification(); 
        }
    }

    void ShowNotification()
    {
        notificationPanel.SetActive(true);

        string longText = "Это очень длинный текст уведомления, в котором точно больше сорока символов.";

        if (longText.Length > 40)
        {
            descriptionText.text = longText.Substring(0, 37) + "...";
        }
        else
        {
            descriptionText.text = longText;
        }

        CancelInvoke("CloseNotification"); 
        Invoke("CloseNotification", 3f);
    }

    public void ClickNotification()
    {
        popupWindow.SetActive(true);
        CloseNotification();
    }

    public void CloseNotification()
    {
        notificationPanel.SetActive(false);
    }
}
