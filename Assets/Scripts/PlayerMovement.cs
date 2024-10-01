using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public GridManager grid;
    public PlayerPrefs stats;
    public First_Dragon xd;
    public bool isMoving;
    public Animator anim;

        #region Inputs for movement
    void Update()
    {

        float distance = 2f;
        RaycastHit hit;
        xd = FindObjectOfType<First_Dragon>();
        Ray ray_Left = new Ray(transform.position, transform.right * -1);
        Ray ray_Right = new Ray(transform.position, transform.right);
        Ray ray_Forward = new Ray(transform.position, transform.forward);
        Ray ray_Back = new Ray(transform.position, transform.forward * -1);
        if (GameManager.Instance.isGaming)
        {
            if (Input.GetKeyDown(KeyCode.A) && !isMoving)
            {
                if (!Physics.Raycast(ray_Left, out hit, distance))
                {
                    if (grid.actualposPlayer.x <= 0)
                    {
                        return;
                    }
                    else
                    {
                        MoveLeft();
                    }
                }
                if (Physics.Raycast(ray_Left, out hit, distance))
                {
                    Debug.Log("cannot move Left");
                    Debug.DrawRay(ray_Left.origin, ray_Left.direction * distance, color: Color.red);
                    return;
                }
            }
            if (Input.GetKeyDown(KeyCode.D) && !isMoving)
            {
                if (!Physics.Raycast(ray_Right, out hit, distance))
                {
                    if (grid.actualposPlayer.x >= grid.ancho - 1)
                    {
                        return;
                    }
                    else
                    {
                        MoveRight();
                    }
                }
                if (Physics.Raycast(ray_Right, out hit, distance))
                {
                    Debug.Log("cannot move Right");
                    Debug.DrawRay(ray_Right.origin, ray_Right.direction * distance, color: Color.red);
                    return;
                }
            }
            if (Input.GetKeyDown(KeyCode.S) && !isMoving)
            {
                if (!Physics.Raycast(ray_Back, out hit, distance))
                {
                    if (grid.actualposPlayer.y <= 0)
                    {
                        return;
                    }
                    else
                    {
                        MoveDown();
                    }
                }
                if (Physics.Raycast(ray_Back, out hit, distance))
                {
                    Debug.Log("cannot move Back");
                    Debug.DrawRay(ray_Back.origin, ray_Back.direction * distance, color: Color.red);
                    return;
                }
            }
            if (Input.GetKeyDown(KeyCode.W) && !isMoving)
            {
                if (!Physics.Raycast(ray_Forward, out hit, distance))
                {
                    if (grid.actualposPlayer.y >= grid.alto - 1)
                    {
                        return;
                    }
                    else
                    {
                        MoveUp();
                    }
                }
                if (Physics.Raycast(ray_Forward, out hit, distance))
                {
                    Debug.Log("cannot move Forward");
                    Debug.DrawRay(ray_Forward.origin, ray_Forward.direction * distance, color: Color.red);
                    return;
                }
            }
        }

    }
    public void MoveLeft()
    {
        anim.SetBool("Attack",false);
        anim.SetBool("Block",false);
        anim.SetBool("Jump",true);
        GameManager.Instance.PlaySound(GameManager.Instance.pasos[Random.Range(0, 3)]);
        grid.actualposPlayer.x -= 1;
        transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
    }
    public void MoveRight()
    {
        anim.SetBool("Attack",false);
        anim.SetBool("Block",false);
        anim.SetBool("Jump",true);
        GameManager.Instance.PlaySound(GameManager.Instance.pasos[Random.Range(0, 3)]);
        grid.actualposPlayer.x += 1;
        transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
    }
    public void MoveUp()
    {
        anim.SetBool("Attack",false);
        anim.SetBool("Block",false);
        anim.SetBool("Jump",true);
        GameManager.Instance.PlaySound(GameManager.Instance.pasos[Random.Range(0, 3)]);
        grid.actualposPlayer.y += 1;
        transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
    }
    public void MoveDown()
    {
        anim.SetBool("Attack",false);
        anim.SetBool("Block",false);
        anim.SetBool("Jump", true);
        GameManager.Instance.PlaySound(GameManager.Instance.pasos[Random.Range(0, 3)]);
        grid.actualposPlayer.y -= 1;
        transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
    }

    #endregion



}
