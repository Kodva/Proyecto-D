using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class First_Dragon : MonoBehaviour
{
    public GridManager grid;
    public PlayerPrefs playerStats;
    public GameObject[] tiles;
    public Material normalMat, atkMat;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<GridManager>();
        playerStats = FindObjectOfType<PlayerPrefs>();
        normalMat = grid.tile.GetComponentInChildren<Renderer>().material;

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void FirstAttacks()
    {
        tiles.SetValue(grid.grid[0, 0], 0, 1);
        normalMat.color = Color.red;

    }
    public IEnumerator FirstAttack()
    {

        yield return null;
    }
}
