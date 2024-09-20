using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigos : MonoBehaviour
{
    public GridManager grid;
    public float maxHP;
    public float currentHP;
    public float defense;
    public int damageMultiplier;
    public int valor_Dragon;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        defense = (Random.Range(3, 8) * GameManager.Instance.level) / 2;
        valor_Dragon = (Random.Range(70, 120) * GameManager.Instance.level) / 2;

    }

    public void Update()
    {
        if (GameManager.Instance.isGaming)
        {
            if (currentHP <= 0)
            {
                GameManager.Instance.DeathDragon();
            }
        }
    }

}
