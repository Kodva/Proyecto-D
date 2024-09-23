
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerPrefs player;
    public List<Items> items;
    void Start()
    {
        items = new List<Items>(items);
    }

    public void ItemUps()
    {
        foreach (var item in items)
        {
            if(item.tipoActual == Items.tipo.Uncommon)
            {
                player.attack += item.atk;
                player.currentHP += item.hp;
                player.goldMultiplier += item.goldMulti;
                player.gameObject.transform.localScale = player.gameObject.transform.localScale * item.scalePJ;
            }
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemUps();
        }
    }
}
