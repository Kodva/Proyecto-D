using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int ancho, alto;
    public TilePrefab tilePrefab;
    public Transform _camera;

    [SerializeField]
    public Dictionary<Vector3, TilePrefab> tiles;

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector3, TilePrefab>();
        for (int i = 0; i < ancho; i+=2)
        {
            for(int j = 0; j < alto; j+=2)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(i,0,j), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";

                tiles[new Vector3(i,0,j)] = spawnedTile;
            }
        }
        _camera.position = new Vector3((ancho/2)-1, 4, -2);
    }
    public TilePrefab GetTileAtPosition(Vector3 position)
    {
        if (tiles.TryGetValue(position, out var tile))
        {
            return tile;
        }
        return null;
    }

}
