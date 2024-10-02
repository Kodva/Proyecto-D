using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD_Player : MonoBehaviour
{
    public PlayerPrefs statsPlayer;
    public TextMeshProUGUI gold_Text;
    public Image PJ_Picture, PJ_Picture_1, PJ_Picture_2;
    public Image[] lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = new Image[statsPlayer.maxHP];
        lives.SetValue(PJ_Picture, 0);
        lives.SetValue(PJ_Picture_1, 1);
        lives.SetValue(PJ_Picture_2, 2);

    }

    // Update is called once per frame
    void Update()
    {
        gold_Text.text = statsPlayer.gold.ToString();
        if (statsPlayer.currentHP == 3)
        {
            lives[2].gameObject.SetActive(true);
            lives[1].gameObject.SetActive(true);
            lives[0].gameObject.SetActive(true);
        }
        if (statsPlayer.currentHP == 2)
        {
            lives[2].gameObject.SetActive(false);
            lives[1].gameObject.SetActive(true);
            lives[0].gameObject.SetActive(true);
        }
        if (statsPlayer.currentHP == 1)
        {
            lives[2].gameObject.SetActive(false);
            lives[1].gameObject.SetActive(false);
            lives[0].gameObject.SetActive(true);
        }
        if (statsPlayer.currentHP == 0)
        {
            lives[2].gameObject.SetActive(false);
            lives[1].gameObject.SetActive(false);
            lives[0].gameObject.SetActive(false);
        }
    }
}
