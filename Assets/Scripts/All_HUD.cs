using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class All_HUD : MonoBehaviour
{
    public CanvasGroup hud, upgradeHUD, deathScreen;
    public PlayerPrefs player;

    void Start()
    {
        hud.alpha = 1.0f;
        hud.interactable = true;
        hud.blocksRaycasts = true;
        upgradeHUD.alpha = 0f;
        upgradeHUD.interactable = false;
        upgradeHUD.blocksRaycasts = false;

    }
    public void ToogleHUD()
    {
        hud.alpha = 0f;
        hud.interactable = false;
        hud.blocksRaycasts = false;
        upgradeHUD.alpha = 1.0f;
        upgradeHUD.interactable = true;
        upgradeHUD.blocksRaycasts = true;
    }
    public void ToogleUpgrade()
    {
        hud.alpha = 1.0f;
        hud.interactable = true;
        hud.blocksRaycasts = true;
        upgradeHUD.alpha = 0f;
        upgradeHUD.interactable = false;
        upgradeHUD.blocksRaycasts = false;
    }
    public void ToogleGameoverON()
    {
        hud.alpha = 0f;
        hud.interactable = false;
        hud.blocksRaycasts = false;
        deathScreen.alpha = 1f;
        deathScreen.interactable = true;
        deathScreen.blocksRaycasts = true;

    }
    public void ToogleGameoverOff()
    {
        hud.alpha = 1f;
        hud.interactable = true;
        hud.blocksRaycasts = true;
        deathScreen.alpha = 0f;
        deathScreen.interactable = false;
        deathScreen.blocksRaycasts = false;

    }
    public void justGameover()
    {
        deathScreen.alpha = 1f;
        deathScreen.interactable = true;
        deathScreen.blocksRaycasts = true;
    }
    public void NextDragon()
    {
        ToogleUpgrade();
        GameManager.Instance.StartCoroutine(GameManager.Instance.StartLevel());
    }
    public void Respawn()
    {
        GameManager.Instance.StartCoroutine(GameManager.Instance.RestartLevel());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
