using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;



public class First_Dragon : MonoBehaviour
{
    public GridManager grid;
    public PlayerPrefs playerStats;
    public GameObject[] tiles;
    public GameObject tileSelected;
    public GameObject rock;
    public GameObject rockSelected;
    public GameObject spawnRocks_L, spawnRocks_R;
    public Material normalMat, atkMat;
    public Collider[] pj;
    public bool frenesi;
    public float timerAttack;
    public Vector3 offset = new Vector3(0, .25f,0);
    public Vector3 secondOffset = new Vector3(.5f, 0, .5f);
    private int length;
    public int attackSelected;
    public LayerMask playerGround;
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        playerStats = FindObjectOfType<PlayerPrefs>();
        tiles = new GameObject[length];
        SelectTimer();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGaming)
        {
            if(timerAttack > 0)
            {
                attackSelected = Random.Range(1, 9);
                timerAttack -= 1* Time.deltaTime;
            }
            if(timerAttack <= 0)
            {
                SelectAttack(attackSelected);
                SelectTimer();
            }
            if (frenesi)
            {

            }
        }

    }
    public void SelectAttack(int atk)
    {
        if (atk == 1)
        {
            Debug.Log("Roca");
            StartCoroutine(RockAttack());
        }
        if (atk == 2)
        {
            Debug.Log("Left");
            StartCoroutine(LeftAttack());
        }
        if (atk == 3)
        {
            Debug.Log("Right");
            StartCoroutine(RightAttack());
        }
        if (atk == 4)
        {
            Debug.Log("Rock");
            StartCoroutine(RockAttack());
        }
        if (atk == 5)
        {
            return;
            //StartCoroutine(RockAttack());
        }
        if (atk == 6)
        {
            return;
            //StartCoroutine(RockAttack());
        }
        if (atk == 7)
        {
            return;
            //StartCoroutine(RockAttack());
        }
        if (atk == 8)
        {
            return;
            //StartCoroutine(RockAttack());
        }
    }

    public void SelectTimer()
    {
        timerAttack = Random.Range(3,8);
    }
    public  IEnumerator RockAttack()
    {
        tileSelected = grid.grid[Random.Range(0,3), Random.Range(0, 3)];
        yield return new WaitForEndOfFrame();
        if(tileSelected == grid.grid[0,0] || tileSelected == grid.grid[1, 0] || tileSelected == grid.grid[2, 0])
        {
            tileSelected = grid.grid[Random.Range(1, 3), Random.Range(1, 3)];
        }
        rockSelected = Instantiate(rock,spawnRocks_L.transform.position, Quaternion.identity);
        yield return new WaitForEndOfFrame();
        rockSelected.transform.DOJump(tileSelected.transform.position + offset, 1.5f, 1, 2);
        yield return new WaitForSeconds(1.8f);
        tileSelected.transform.DOShakePosition(.5f, .25f, 20, 30);
    }

    public IEnumerator LeftAttack()
    {
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
        yield return new WaitForSeconds(2f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, .5f, playerGround);
        }
        yield return new WaitForEndOfFrame();
        if ( pj.Length > 0)
        {
            Debug.Log("has sido golpeado");
            playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
        }
        yield return new WaitForEndOfFrame();
        pj = new Collider[0];
    }
    public IEnumerator RightAttack()
    {
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
        yield return new WaitForSeconds(2f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, .5f, playerGround);
        }
        yield return new WaitForEndOfFrame();
        if (pj.Contains(playerStats.GetComponent<Collider>()))
        {
            Debug.Log("has sido golpeado");
            playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
        }
        yield return new WaitForEndOfFrame();
        pj = new Collider[0];
    }

}
