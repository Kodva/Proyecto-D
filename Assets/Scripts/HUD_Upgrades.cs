using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD_Upgrades : MonoBehaviour
{
    public int cantidadMejoras;
    public PlayerPrefs stats;
    public Inventory inventory;
    public TextMeshProUGUI item_1_Text, item_2_Text, item_3_Text,money_Text, mejoras_Text, hp_Text, sword_Text;
    public Image item_1_Image, item_2_Image, item_3_Image;
    public float valor_item, valor_Sword, valor_Hp;

    void Start()
    {
        valor_Hp = 100;
        valor_Sword = 100;
        valor_item = 130;
        item_1_Text.text = valor_item.ToString();
        item_2_Text.text = valor_item.ToString();
        item_3_Text.text = valor_item.ToString();
    }

    void Update()
    {
        money_Text.text = stats.gold.ToString();
        mejoras_Text.text = cantidadMejoras.ToString();
        hp_Text.text = valor_Hp.ToString();
        sword_Text.text = valor_Sword.ToString();
        item_1_Text.text = valor_item.ToString();
        item_2_Text.text = valor_item.ToString();
        item_3_Text.text = valor_item.ToString();
    }

    public void UpgradeATK()
    {
        if (cantidadMejoras > 0)
        {
            if (stats.gold >= valor_Sword)
            {
                stats.currentHP += 1;
                valor_Hp = (valor_Hp + 100) / 2;
                cantidadMejoras--;
            }
            else return;
        }
        else return;
    }
    public void UpgradeHP()
    {
        if (cantidadMejoras > 0)
        {
            if (stats.gold >= valor_Hp)
            {
                if(stats.currentHP == stats.maxHP)
                {
                    stats.maxHP++;
                    valor_Hp = (valor_Hp + 100) / 2;
                    cantidadMejoras--;
                }
                else
                stats.currentHP += 1;
                valor_Hp = (valor_Hp + 100) / 2;
                cantidadMejoras--;
            }
            else return;
        }
        else return;
    }
    public void TakeItem(int number)
    {
        if (cantidadMejoras > 0)
        {
            switch (number)
            {
                case 1:
                //Elegir item 1
                    break;
                case 2:
                //Elegir item 2
                    break;
                case 3:
                //Elegir item 3
                    break;
            }
            cantidadMejoras--;
        }
        else return;
    }
    public void SetMejoras()
    {
        cantidadMejoras = 1;
    }
}
