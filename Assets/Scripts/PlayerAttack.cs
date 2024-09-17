using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerPrefs stats;
    public PlayerMovement mov;
    public Enemigos dragon;
    public Rock rock;

    // Start is called before the first frame update
    void Start()
    {
        dragon = FindObjectOfType<Enemigos>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 1.8f;
        RaycastHit hit;
        Ray atk_ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(atk_ray.origin,atk_ray.direction * distance);
        //Physics.Raycast(atk_ray, out hit, distance);
        //rock = hit.collider.GetComponent<Rock>();
        if (Input.GetKeyDown(KeyCode.J) && !mov.isMoving && !Physics.Raycast(atk_ray, out hit, distance))
        {
            if (rock != null)
            {
                rock.hp_rock -= (1 + stats.attack) * stats.attackRockMultiplier;
            }
            else
                dragon.currentHP -= (1 + stats.attack) / dragon.defense;
        }
    }
}
