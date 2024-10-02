using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public PlayerPrefs statsplayer;
    public PlayerAttack pj;
    public PlayerMovement pj_mov;
    public float hp_rock;
    public float valor;
    // Start is called before the first frame update
    void Start()
    {
        statsplayer = FindObjectOfType<PlayerPrefs>();
        pj = FindObjectOfType<PlayerAttack>();
        pj_mov = FindObjectOfType<PlayerMovement>();
        hp_rock = (30 * GameManager.Instance.level) / 2;
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
        GameManager.Instance.PlaySound(GameManager.Instance.rockDestroy);
        pj.rock = null;
        statsplayer.gold += coins;
        Destroy(gameObject);
        GameManager.Instance.PlaySound(GameManager.Instance.oro_Caido);
        GameManager.Instance.PlaySound(GameManager.Instance.oro_Recolectado);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pj_mov.MoveDown();
        }
    }

}
