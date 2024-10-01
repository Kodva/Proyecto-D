using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HUD_Player : MonoBehaviour
{
    public PlayerPrefs statsPlayer;
    public TextMeshProUGUI gold_Text;
    public Image PJ_Picture;
    public Image[] lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gold_Text.text = statsPlayer.gold.ToString();
    }
}
