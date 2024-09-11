using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[,] grid;
    public int ancho, alto;
    public float spacing = 1;
    public GameObject tile;
    public Transform player;
    public Vector3 offset = new Vector3(-0.5f, 1, -0.5f);
    public Vector2 actualposPlayer;
    public Transform _camera;


    private void Start()
    {


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
        _camera.position = new Vector3((ancho + (spacing*ancho)- (spacing*2))/2, 6, (((alto + (spacing * alto) - (spacing*2) - 2))/2)-5.5f);
        actualposPlayer = new Vector2((ancho - 1) / 2, (alto - 1) / 2);
        player.transform.DOJump(grid[(int)actualposPlayer.x, (int)actualposPlayer.y].transform.position + offset, 1, 1, .25f);
        
    }
    public void TrygettingTiles(Vector2 pos)
    {

    }


}
