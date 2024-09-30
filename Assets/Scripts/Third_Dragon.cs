using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Third_Dragon : MonoBehaviour
{
    public GridManager grid;
    public PlayerAttack pj_Atk;
    public PlayerPrefs playerStats;
    public PlayerMovement pj_mov;
    public GameObject[] tiles;
    public GameObject tileSelected;
    public GameObject rock;
    public GameObject rockSelected;
    public GameObject spawnRocks_L, spawnRocks_R;
    public Material normalMat, atkMat;
    public Collider[] pj;
    public bool frenesi;
    public bool isAttacking;
    public float timerAttack;
    public Vector3 offset = new Vector3(0, .25f, 0);
    public Vector3 secondOffset = new Vector3(.5f, 0, .5f);
    private int length;
    public int attackSelected;
    public LayerMask playerGround;
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        playerStats = FindObjectOfType<PlayerPrefs>();
        pj_Atk = FindObjectOfType<PlayerAttack>();
        pj_mov = FindObjectOfType<PlayerMovement>();
        tiles = new GameObject[length];
        SelectTimer();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.isGaming && !isAttacking)
        {
            if (timerAttack > 0)
            {
                attackSelected = Random.Range(1, 13);
                timerAttack -= 1 * Time.deltaTime;
            }
            if (timerAttack <= 0)
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
            Debug.Log("Front");
            StartCoroutine(AllFrontAttack());
        }
        if (atk == 5)
        {
            Debug.Log("Diagonal Right");
            StartCoroutine(DiagonalRightAttack());
        }
        if (atk == 6)
        {
            Debug.Log("Diagonal Left");
            StartCoroutine(DiagonalLeftAttack());
        }
        if (atk == 7)
        {
            Debug.Log("All left");
            StartCoroutine(AllLeftAttack());
        }
        if (atk == 8)
        {
            Debug.Log("All right");
            StartCoroutine(AllRightAttack());
        }
        if (atk == 9)
        {
            Debug.Log("All back");
            StartCoroutine(AllBackAttack());
        }
        if (atk == 10)
        {
            Debug.Log("Almost all");
            StartCoroutine(AlmostAllAttack());
        }
        if (atk == 11)
        {
            Debug.Log("Roca");
            StartCoroutine(RockAttack());
        }
        if (atk == 12)
        {
            Debug.Log("Roca");
            StartCoroutine(RockAttack());
        }
        if (atk == 13)
        {
            Debug.Log("Roca");
            StartCoroutine(RockAttack());
        }
    }

    public void SelectTimer()
    {
        timerAttack = Random.Range(1, 2.5f);
    }
    public IEnumerator RockAttack()
    {
        isAttacking = true;
        tileSelected = grid.grid[Random.Range(0, 3), Random.Range(0, 3)];
        yield return new WaitForEndOfFrame();
        if (tileSelected == grid.grid[0, 0] || tileSelected == grid.grid[1, 0] || tileSelected == grid.grid[2, 0])
        {
            tileSelected = grid.grid[Random.Range(1, 3), Random.Range(1, 3)];
        }
        rockSelected = Instantiate(rock, spawnRocks_L.transform.position, Quaternion.identity);
        yield return new WaitForEndOfFrame();
        rockSelected.transform.DOJump(tileSelected.transform.position + offset, 1.5f, 1, 2);
        yield return new WaitForSeconds(1.8f);
        tileSelected.transform.DOShakePosition(.5f, .25f, 20, 30);
        isAttacking = false;
    }

    public IEnumerator LeftAttack()
    {
        isAttacking = true;
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, .5f, playerGround);
        }
        if (pj.Contains(playerStats.GetComponent<Collider>()))
        {
            Debug.Log("has sido golpeado");
            playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
        }
        yield return new WaitForEndOfFrame();
        pj = new Collider[0];
        isAttacking = false;
    }
    public IEnumerator RightAttack()
    {
        isAttacking = true;
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator DiagonalRightAttack()
    {
        isAttacking = true;
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 0], 2);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator DiagonalLeftAttack()
    {
        isAttacking = true;
        length = 3;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 0], 2);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator AllLeftAttack()
    {
        isAttacking = true;
        length = 6;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 0], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 0], 5);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator AllRightAttack()
    {
        isAttacking = true;
        length = 6;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 0], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 0], 5);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator AllFrontAttack()
    {
        isAttacking = true;
        length = 6;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 5);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator AllBackAttack()
    {
        isAttacking = true;
        length = 6;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 0], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 0], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 0], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 5);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }
    public IEnumerator AlmostAllAttack()
    {
        isAttacking = true;
        length = 8;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 0], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 2], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 0], 5);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 6);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 2], 7);
        yield return new WaitForEndOfFrame();
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = atkMat;
        }
        yield return new WaitForSeconds(.2f);
        foreach (GameObject tile in tiles)
        {
            tile.GetComponentInChildren<Renderer>().material = normalMat;
        }
        yield return new WaitForSeconds(.5f);
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
        isAttacking = false;
    }

}
