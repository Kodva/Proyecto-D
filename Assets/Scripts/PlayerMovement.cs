using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public GridManager grid;
    public bool isMoving;
    public PlayerPrefs stats;
    public First_Dragon xd;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xd = FindObjectOfType<First_Dragon>();

        if (Input.GetKeyDown(KeyCode.A) && isMoving== false)
        {
            if(grid.actualposPlayer.x <= 0)
            {
                return;
            }
            else
            {
                grid.actualposPlayer.x -= 1;
                transform.DOJump(grid.grid[(int)grid.actualposPlayer.x,(int)grid.actualposPlayer.y].transform.position + grid.offset,1,1,stats.speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && isMoving == false)
        {
            if (grid.actualposPlayer.x >= grid.ancho-1)
            {
                return;
            }
            else
            {
                grid.actualposPlayer.x += 1;
                transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
            }

        }
        if (Input.GetKeyDown(KeyCode.S) && isMoving == false)
        {
            if (grid.actualposPlayer.y <= 0)
            {
                return;
            }
            else
            {
                grid.actualposPlayer.y -= 1;
                transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && isMoving == false)
        {
            if (grid.actualposPlayer.y >= grid.alto-1)
            {
                return;
            }
            else
            {
                grid.actualposPlayer.y += 1;
                transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(xd.LeftAttack());
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(xd.RightAttack());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(xd.RockAttack());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isMoving = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isMoving = true;
        }
    }
}
