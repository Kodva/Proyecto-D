using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public PlayerPrefs statsplayer;
    public float hp_rock;
    public float valor;

    // Start is called before the first frame update
    void Start()
    {
        statsplayer = FindObjectOfType<PlayerPrefs>();
        hp_rock = (15 * GameManager.Instance.level) / 2;
        valor = ((Random.Range(20,50) * GameManager.Instance.level)/2)* statsplayer.goldMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp_rock <= 0)
        {
            DestroyRock(valor);
        }
    }
    public void DestroyRock(float coins)
    {
        statsplayer.gold += coins;
        Destroy(gameObject);
    }

}
