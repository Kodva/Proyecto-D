using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class First_Dragon : MonoBehaviour
{
    public GridManager grid;
    public PlayerPrefs playerStats;
    public GameObject[] tiles;
    public GameObject tileSelected;
    public GameObject rock;
    public GameObject spawnRocks_L, spawnRocks_R;
    public Material normalMat, atkMat;
    public Vector3 offset = new Vector3(0, .25f,0);
    private int length = 9;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        playerStats = FindObjectOfType<PlayerPrefs>();
        tiles = new GameObject[length];
    }


    // Update is called once per frame
    void Update()
    {

    }
    public  IEnumerator RockAttack()
    {
        tileSelected = grid.grid[Random.Range(0,3), Random.Range(0, 3)];
        yield return new WaitForEndOfFrame();
        if(tileSelected == grid.grid[0,0] || tileSelected == grid.grid[1, 0] || tileSelected == grid.grid[2, 0])
        {
            tileSelected = grid.grid[Random.Range(1, 3), Random.Range(1, 3)];
        }
        rock = Instantiate(rock,spawnRocks_L.transform.position, Quaternion.identity);
        yield return new WaitForEndOfFrame();
        rock.transform.DOJump(tileSelected.transform.position + offset, 1.5f, 1, 2);
        yield return new WaitForSeconds(1.8f);
        tileSelected.transform.DOShakePosition(.5f, .25f, 20, 30);
    }

    public IEnumerator LeftAttack()
    {
        normalMat = grid.tile.GetComponentInChildren<Renderer>().material;
        tiles.SetValue(grid.grid[0, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[0, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
    }
    public IEnumerator RightAttack()
    {
        normalMat = grid.tile.GetComponentInChildren<Renderer>().material;
        tiles.SetValue(grid.grid[2, 2], 0);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[2, 1], 1);
        yield return new WaitForEndOfFrame();
        tiles.SetValue(grid.grid[1, 1], 2);
    }
}
