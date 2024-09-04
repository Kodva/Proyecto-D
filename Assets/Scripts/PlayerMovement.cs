using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GridManager grid;
    public Vector3[] posiblePos;
    // Start is called before the first frame update
    void Start()
    {
        grid.GetTileAtPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
