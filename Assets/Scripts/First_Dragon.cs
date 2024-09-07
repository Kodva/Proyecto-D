using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class First_Dragon : Enemigos
{
    public GridManager grid;
    public Image lifebar;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100;
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.fillAmount = lifebar.fillAmount % maxHP;
    }
}
