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
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            GameManager.Instance.isGaming = false;
            GameManager.Instance.StartCoroutine(GameManager.Instance.DeathPlayer());
        }

    }

    public void ReceiveDamage(int damage)
    {
        currentHP -= 1 * damage;
    }
}
