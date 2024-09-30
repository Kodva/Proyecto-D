using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public enum tipo {Uncommon, Rare, Epic, Legendary }
    public float atk;
    public float hp;
    public float goldMulti;
    public float scalePJ;
    public tipo tipoActual;
    public Image portrait;
    public TextMeshProUGUI itemName;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
