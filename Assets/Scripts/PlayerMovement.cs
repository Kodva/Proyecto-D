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
        #region Inputs for movement

        float distance = 2f;
        RaycastHit hit;
        xd = FindObjectOfType<First_Dragon>();
        Ray ray_Left = new Ray(transform.position, transform.right * -1);
        Ray ray_Right = new Ray(transform.position, transform.right);
        Ray ray_Forward = new Ray(transform.position, transform.forward);
        Ray ray_Back = new Ray(transform.position, transform.forward * -1);

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
                    grid.actualposPlayer.x -= 1;
                    transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
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
                    grid.actualposPlayer.x += 1;
                    transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
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
            if (!Physics.Raycast(ray_Back, out hit , distance))
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
            if (Physics.Raycast(ray_Back, out hit, distance))
            {
                Debug.Log("cannot move Back");
                Debug.DrawRay(ray_Back.origin, ray_Back.direction * distance, color: Color.red);
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            if(!Physics.Raycast(ray_Forward, out hit , distance))
            {
                if (grid.actualposPlayer.y >= grid.alto - 1)
                {
                    return;
                }
                else
                {
                    grid.actualposPlayer.y += 1;
                    transform.DOJump(grid.grid[(int)grid.actualposPlayer.x, (int)grid.actualposPlayer.y].transform.position + grid.offset, 1, 1, stats.speed);
                }
            }
            if (Physics.Raycast(ray_Forward,out hit , distance))
            {
                Debug.Log("cannot move Forward");
                Debug.DrawRay(ray_Forward.origin, ray_Forward.direction * distance, color: Color.red);
                return;
            }
        }
        #endregion
        #region Inputs for Testing

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

        #endregion

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
