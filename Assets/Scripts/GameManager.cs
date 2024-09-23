using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridManager gridManager;
    public int level;
    public Enemigos enemigos;
    public Inventory playerItems;
    public GameObject[] dragons;
    public GameObject dragonBoss;
    public GameObject spawnPoint;
    public PlayerMovement playerMov;
    public PlayerAttack playerAtk;
    public HUD_Dragons hud_D;
    public All_HUD hud;
    public bool isGaming;
    public bool isUpgrading;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
        
    }
    public IEnumerator StartLevel()
    {
        if (level <= 0)
        {
            gridManager.GenerateGrid();
        }
        isUpgrading = false;
        yield return new WaitForSeconds(.5f);
        level++;
        yield return new WaitForSeconds(.5f);
        dragonBoss = Instantiate(dragons[Random.Range(0,4)],spawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        enemigos = FindObjectOfType<Enemigos>();
        yield return new WaitForSeconds(.5f);
        enemigos.maxHP = 100 + (level * 500) / 2;
        yield return new WaitForSeconds(.5f);
        enemigos.currentHP = enemigos.maxHP;
        yield return new WaitForSeconds(1f);
        hud_D.dragon = dragonBoss.GetComponent<Enemigos>();
        yield return new WaitForSeconds(.5f);
        playerAtk.dragon = dragonBoss.GetComponent<Enemigos>();
        yield return new WaitForSeconds(.5f);
        playerMov.isMoving = false;
        yield return new WaitForSeconds(.5f);
        hud_D.lifebarEase.maxValue = enemigos.maxHP;
        hud_D.lifebarEase.value = 0;
        yield return new WaitForSeconds(1f);
        hud_D.lifebarEase.value = Mathf.Lerp(hud_D.lifebarEase.value, enemigos.maxHP, 1f);
        yield return new WaitForSeconds(1f);
        hud_D.lifebar.maxValue = enemigos.maxHP;
        hud_D.lifebar.value = 0;
        yield return new WaitForSeconds(1f);
        hud_D.lifebar.value = Mathf.Lerp(hud_D.lifebar.value, enemigos.maxHP, 1f);
        yield return new WaitForSeconds(1.5f);
        isGaming = true;
    }

    public IEnumerator FinishLevel()
    {
        hud.ToogleHUD();
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator DeathPlayer()
    {
        yield return new WaitForEndOfFrame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(StartLevel());
        }
    }
    public void DeathDragon()
    {
        isGaming = false;
        Destroy(dragonBoss);
        playerAtk.stats.gold += enemigos.valor_Dragon;
        StartCoroutine(FinishLevel());
        isUpgrading = true;
    }
}
