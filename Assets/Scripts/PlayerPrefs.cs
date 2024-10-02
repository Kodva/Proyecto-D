using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{

    public float maxHP;
    public float currentHP;
    public float attack;
    public float defense;
    public float speed;
    public float gold;
    public float goldMultiplier;
    public float attackRockMultiplier;
    public bool isdeath;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0 && GameManager.Instance.isGaming)
        {
            isdeath = true;
        }
        if (isdeath)
        {
            GameManager.Instance.StartCoroutine(GameManager.Instance.DeathPlayer());
        }

    }

    public void ReceiveDamage(int damage)
    {
        GameManager.Instance.PlaySound(GameManager.Instance.dano_Player[Random.Range(0, 4)]);
        currentHP -= 1 * damage;
    }


    
}
