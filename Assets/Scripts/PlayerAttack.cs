using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerPrefs stats;
    public PlayerMovement mov;
    public Enemigos dragon;

    // Start is called before the first frame update
    void Start()
    {
        dragon = FindObjectOfType<Enemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && mov.isMoving ==false)
        {
            dragon.currentHP -= (1 + stats.attack)/dragon.defense;
            
        }
        
    }

}
