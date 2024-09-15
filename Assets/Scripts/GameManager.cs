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
    public HUD_Dragons hud;
    public bool isGaming;
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
        gridManager.GenerateGrid();
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
        yield return new WaitForSeconds(.5f);
        hud.dragon = dragonBoss.GetComponent<Enemigos>();
        yield return new WaitForSeconds(.5f);
        playerAtk.dragon = dragonBoss.GetComponent<Enemigos>();
        isGaming = true;
        yield return new WaitForSeconds(.5f);
        playerMov.isMoving = false;
        yield return new WaitForSeconds(.5f);
        hud.lifebarEase.maxValue = enemigos.maxHP;
        hud.lifebar.maxValue = enemigos.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(StartLevel());

        }
    }
}
