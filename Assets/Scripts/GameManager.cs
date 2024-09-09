using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GridManager gridManager;
    public int level;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        
    }
    public void StartLevel()
    {
        gridManager.GenerateGrid();
        level++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
