using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    public Animator anim;
    
    
    public void AnimationAttack()
    {
        anim.SetBool("Attack",false);
    }
    
    public void AnimationJump()
    {
        anim.SetBool("Jump",false);
    }    
    
}
