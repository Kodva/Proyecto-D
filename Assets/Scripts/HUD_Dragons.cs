using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Dragons : MonoBehaviour
{
    public Slider lifebar , lifebar_1;
    public Slider lifebarEase, lifebarEase_1;
    public Enemigos dragon;
    public float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (GameManager.Instance.isGaming)
        {
            if (lifebar.value != dragon.currentHP)
            {
                lifebar.value = dragon.currentHP;
            }
            if (lifebarEase.value != lifebar.value)
            {
                lifebarEase.value = Mathf.Lerp(lifebarEase.value, dragon.currentHP, lerpSpeed);
            }
            if (lifebar_1.value != dragon.currentHP)
            {
                lifebar_1.value = dragon.currentHP;
            }
            if (lifebarEase_1.value != lifebar_1.value)
            {
                lifebarEase_1.value = Mathf.Lerp(lifebarEase_1.value, dragon.currentHP, lerpSpeed);
            }
        }
    }

}
