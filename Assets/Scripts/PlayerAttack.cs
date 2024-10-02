using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerPrefs stats;
    public PlayerMovement mov;
    public Enemigos dragon;
    public Rock rock;
    public bool blocking;

    public Animator anim;
    void Start()
    {
        dragon = FindObjectOfType<Enemigos>();
    }

    void Update()
    {
        if (GameManager.Instance.isGaming)
        {
            float distance = 1.8f;
            RaycastHit hit;
            Ray atk_ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(atk_ray.origin, atk_ray.direction * distance);
            if (Input.GetKeyDown(KeyCode.J) && !mov.isMoving)
            {
                anim.SetBool("Jump",false);
                anim.SetBool("Block",false);
                anim.SetBool("Attack",true);
                if (Physics.Raycast(atk_ray, out hit, distance))
                {
                    if (hit.collider.CompareTag("Rock"))
                    {
                        GameManager.Instance.PlaySound(GameManager.Instance.golpe_Roca[Random.Range(0,3)]);
                        rock = hit.collider.GetComponentInChildren<Rock>();
                        rock.hp_rock -= (1 + stats.attack) * stats.attackRockMultiplier;
                    }
                }
                if (!Physics.Raycast(atk_ray, out hit, distance))
                {
                    GameManager.Instance.PlaySound(dragon.self_Dragon_damage);
                    GameManager.Instance.PlaySound(GameManager.Instance.atk_Dragon[Random.Range(0, 3)]);
                    GameManager.Instance.PlaySound(GameManager.Instance.atk_pj[Random.Range(0, 4)]);
                    dragon.currentHP -= (1 + stats.attack) / dragon.defense;
                }
            }
            if (Input.GetKey(KeyCode.K) && !mov.isMoving)
            {
                anim.SetBool("Jump",false);
                anim.SetBool("Attack",false);
                anim.SetBool("Block",true);
                blocking = true;

            }
            else blocking = false;

            if (Input.GetKeyUp(KeyCode.K))
            {
                anim.SetBool("Block",false);
            }
        }

    }
}
