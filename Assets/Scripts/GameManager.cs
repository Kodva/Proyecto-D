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
    public GameObject spawnPoint;
    public PlayerMovement playerMov;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }
    public IEnumerator StartLevel()
    {
        gridManager.GenerateGrid();
        level++;
        yield return new WaitForSeconds(1f);
        Instantiate(dragons[Random.Range(0,4)],spawnPoint.transform.position, Quaternion.identity);
        enemigos = FindObjectOfType<Enemigos>();
        enemigos.maxHP = 100 + (level * 2000) / 2;
        playerMov.isMoving = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
