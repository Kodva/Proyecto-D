using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_HUD : MonoBehaviour
{
    public CanvasGroup hud, upgradeHUD;
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
    void Update()
    {
        
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
    public void NextDragon()
    {
        ToogleUpgrade();
        GameManager.Instance.StartCoroutine(GameManager.Instance.StartLevel());
    }
}
