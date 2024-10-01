using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireAnimation : MonoBehaviour
{
    public VisualEffect fire;
    // Start is called before the first frame update
    void Start()
    {
       fire.Stop(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void FireOn()
    {
        fire.Play();
    }
   public void FireOff()
   {
       fire.Stop();
   }
}
