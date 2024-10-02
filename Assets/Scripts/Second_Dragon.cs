using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.VFX;
using Random = UnityEngine.Random;


public class Second_Dragon : MonoBehaviour
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
    public GameObject atkvfx, atkvfxclone, rockvfx;
    public Material normalMat, atkMat;
    public Collider[] pj;
    public Enemigos self;
    public bool frenesi;
    public bool isAttacking;
    public float timerAttack;
    public Vector3 offset = new Vector3(0, .25f, 0);
    public Vector3 secondOffset = new Vector3(.5f, 0, .5f);
    private int length;
    public int attackSelected;
    public LayerMask playerGround;
    public AudioClip self_Fire;

    private void Awake()
    {
       
    }

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
                attackSelected = Random.Range(1, 8);
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
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Roca");
            StartCoroutine(RockAttack());
        }

        if (atk == 2)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Left");
            StartCoroutine(LeftAttack());
        }

        if (atk == 3)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Right");
            StartCoroutine(RightAttack());
        }

        if (atk == 4)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Almost all");
            StartCoroutine(AlmostAllAttack());
        }

        if (atk == 5)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Flame");
            StartCoroutine(FlameAtk());
        }

        if (atk == 6)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
            Debug.Log("Mordisco");
            StartCoroutine(JawFront());
        }

        if (atk == 7)
        {
            self.anim.SetInteger("Ataque", atk);
            self.anim.SetTrigger("Atk");
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
        GameManager.Instance.PlaySound(GameManager.Instance.pisada);
        yield return new WaitForEndOfFrame();
        rockSelected.transform.DOJump(tileSelected.transform.position + offset, 1.5f, 1, 2);
        yield return new WaitForSeconds(1.8f);
        GameManager.Instance.PlaySound(GameManager.Instance.piedra_Impacto);
        tileSelected.transform.DOShakePosition(.5f, .25f, 20, 30);
        isAttacking = false;
        self.anim.SetTrigger("Idle");
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

        void ChangeTilesMaterial(Material material, float vfxDuration)
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponentInChildren<Renderer>().material = material;
                var atkvfxclone = Instantiate(atkvfx, tile.transform);
                Destroy(atkvfxclone, vfxDuration);
            }
        }

        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.5f);
        GameManager.Instance.PlaySound(GameManager.Instance.garra);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset,
                tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    Debug.Log("has sido golpeado");
                    playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    break;
                }
            }
        }

        yield return new WaitForSeconds(.5f);
        pj = new Collider[0];
        isAttacking = false;
        self.anim.SetTrigger("Idle");
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

        void ChangeTilesMaterial(Material material, float vfxDuration)
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponentInChildren<Renderer>().material = material;
                var atkvfxclone = Instantiate(atkvfx, tile.transform);
                Destroy(atkvfxclone, vfxDuration);
            }
        }

        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.5f);
        GameManager.Instance.PlaySound(GameManager.Instance.garra);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset,
                tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    Debug.Log("has sido golpeado");
                    playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    break;
                }
            }
        }

        yield return new WaitForEndOfFrame();
        pj = new Collider[0];
        isAttacking = false;
        self.anim.SetTrigger("Idle");
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

        void ChangeTilesMaterial(Material material, float vfxDuration)
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponentInChildren<Renderer>().material = material;
                var atkvfxclone = Instantiate(atkvfx, tile.transform);
                Destroy(atkvfxclone, vfxDuration);
            }
        }

        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.5f);
        GameManager.Instance.PlaySound(GameManager.Instance.pisada);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset,
                tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    Debug.Log("has sido golpeado");
                    playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    break;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        pj = new Collider[0];
        isAttacking = false;
        self.anim.SetTrigger("Idle");
    }

    public IEnumerator JawFront()
    {
        isAttacking = true;
        length = 2;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 1);
        yield return new WaitForEndOfFrame();

        void ChangeTilesMaterial(Material material, float vfxDuration)
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponentInChildren<Renderer>().material = material;
                var atkvfxclone = Instantiate(atkvfx, tile.transform);
                Destroy(atkvfxclone, vfxDuration);
            }
        }

        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        

        yield return new WaitForSeconds(.5f);
        GameManager.Instance.PlaySound(GameManager.Instance.mordida);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset, tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    Debug.Log("has sido golpeado");
                    playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    break;
                }
            }
        }
        yield return new WaitForSeconds(.5f);
        pj = new Collider[0];
        yield return new WaitForEndOfFrame();
        isAttacking = false;
        self.anim.SetTrigger("Idle");
    }
    public IEnumerator FlameAtk()
    {
        isAttacking = true;
        length = 7;
        yield return new WaitForEndOfFrame();
        tiles = new GameObject[length];
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 3);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 0], 4);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 0], 5);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 0], 6);
        yield return new WaitForEndOfFrame();
        void ChangeTilesMaterial(Material material, float vfxDuration)
        {
            foreach (GameObject tile in tiles)
            {
                tile.GetComponentInChildren<Renderer>().material = material;
                var atkvfxclone = Instantiate(atkvfx, tile.transform);
                Destroy(atkvfxclone, vfxDuration);
            }
        }
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(atkMat, 2);
        yield return new WaitForSeconds(.2f);
        ChangeTilesMaterial(normalMat, 0);
        yield return new WaitForSeconds(2.5f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset, tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    if (!pj_Atk.blocking)
                    {
                        Debug.Log("has sido golpeado");
                        playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    }
                    if (pj_Atk.blocking)
                    {
                        GameManager.Instance.PlaySound(GameManager.Instance.block_pj[Random.Range(0, 3)]);
                        Debug.Log("Bloqueaste");
                    }
                    break;
                }
            }
        }
        GameManager.Instance.PlaySound(self_Fire);
        yield return new WaitForSeconds(.2f);
        pj = new Collider[0];
        yield return new WaitForSeconds(.3f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset, tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    if (!pj_Atk.blocking)
                    {
                        Debug.Log("has sido golpeado");
                        playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    }
                    if (pj_Atk.blocking)
                    {
                        GameManager.Instance.PlaySound(GameManager.Instance.block_pj[Random.Range(0, 3)]);
                        Debug.Log("Bloqueaste");
                    }
                    break;
                }
            }
        }
        yield return new WaitForSeconds(.2f);
        pj = new Collider[0];
        yield return new WaitForSeconds(.3f);
        foreach (GameObject tile in tiles)
        {
            pj = Physics.OverlapSphere(tile.transform.position + offset + secondOffset, 1f, playerGround);
            Debug.DrawLine(tile.transform.position + offset + secondOffset, tile.transform.position + new Vector3(0, 2f, 0));
            foreach (Collider player in pj)
            {
                if (player == pj_mov.GetComponent<Collider>())
                {
                    if (!pj_Atk.blocking)
                    {
                        Debug.Log("has sido golpeado");
                        playerStats.ReceiveDamage(transform.GetComponent<Enemigos>().damageMultiplier);
                    }
                    if (pj_Atk.blocking)
                    {
                        GameManager.Instance.PlaySound(GameManager.Instance.block_pj[Random.Range(0, 3)]);
                        Debug.Log("Bloqueaste");
                    }
                    break;
                }
            }
        }
        yield return new WaitForSeconds(1f);
        pj = new Collider[0];
        isAttacking = false;
        self.anim.SetTrigger("Idle");
    }

}
