using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    public GameObject[,] grid;
    public int ancho, alto;
    public float spacing = 1;
    public GameObject tile;
    public Transform player;
    public Vector3 offset = new Vector3(0, 1, 0);
    public Vector2 actualposPlayer;
    public Transform _camera;


    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new GameObject[ancho, alto];
        Vector3 startPos = transform.position;
        for (int i = 0; i < ancho; i++)
        {
            for(int j = 0; j < alto; j++)
            {
                GameObject tiles = Instantiate(tile);
                startPos = new Vector3(i*spacing,0,j*spacing);
                tiles.transform.position = startPos;
                grid[i,j] = tiles;
                tiles.GetComponent<TilePrefab>().id = new Vector2(i,j);
            }
        }
        _camera.position = new Vector3(2, 6, -4);
        actualposPlayer = new Vector2((ancho - 1) / 2, (alto - 1) / 2);
        player.transform.DOJump(grid[(int)actualposPlayer.x, (int)actualposPlayer.y].transform.position + offset, 1, 1, .25f);
        
    }

}
