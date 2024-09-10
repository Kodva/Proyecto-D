using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    public GridManager grid;
    public Slider lifebar;
    public Slider lifebarEase;
    public float learpSpeed = 0.05f;
    public float maxHP;
    public float currentHP;
    public float defense;
    // Start is called before the first frame update
    void Start()
    {
        defense = (Random.Range(3, 8) * GameManager.Instance.level) / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifebar.value != currentHP)
        {
            lifebar.value = currentHP;
        }
        if (lifebarEase.value != lifebar.value)
        {
            lifebarEase.value = Mathf.Lerp(lifebarEase.value, currentHP, learpSpeed);
        }
    }
    
}
