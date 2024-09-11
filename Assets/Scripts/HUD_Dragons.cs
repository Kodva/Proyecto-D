using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Dragons : MonoBehaviour
{
    public Slider lifebar;
    public Slider lifebarEase;
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
        }
    }

}
