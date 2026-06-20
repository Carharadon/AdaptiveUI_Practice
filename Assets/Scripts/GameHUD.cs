using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;  

public class GameHUD : MonoBehaviour
{
    [Header("Player Stats")]
    public int coins = 100;
    public float currentHp = 100f;
    public float maxHp = 100f;

    [Header("UI Elements (HUD)")]
    public Text coinsText;
    public Slider hpSlider;

    [Header("Panels")]
    public GameObject debugPanel;
    public GameObject pausePanel; 
    public GameObject confirmPanel; 

    void Start()
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = currentHp;

        UpdateUI();

        debugPanel.SetActive(false);
        pausePanel.SetActive(false);
        confirmPanel.SetActive(false);
    }

    void UpdateUI()
    {
        coinsText.text = "Монеты: " + coins;
    }

    public void AddCoins()
    {
        coins += 50;
        UpdateUI();
    }

    public void RemoveCoins()
    {
        coins -= 50;
        if (coins < 0) coins = 0; 
        UpdateUI();
    }

    public void AddHP()
    {
        currentHp += 20f;
        if (currentHp > maxHp) currentHp = maxHp;

        hpSlider.DOValue(currentHp, 0.3f);
    }

    public void RemoveHP()
    {
        currentHp -= 20f;
        if (currentHp < 0) currentHp = 0;

        hpSlider.DOValue(currentHp, 0.3f);
    }

    public void ToggleDebugPanel()
    {
        debugPanel.SetActive(!debugPanel.activeSelf);
    }
    public void OpenPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AskToExit()
    {
        confirmPanel.SetActive(true);
    }

    public void ConfirmExitYes()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    public void ConfirmExitNo()
    {
        confirmPanel.SetActive(false);
    }
}
