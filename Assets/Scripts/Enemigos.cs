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
    // Start is called before the first frame update
    void Start()
    {
        defense = (Random.Range(3, 8) * GameManager.Instance.level) / 2;
        
    }
    
}
