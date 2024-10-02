using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.VFX;
using UnityEngine.VFX;
public class VFXActivate1 : MonoBehaviour
{
    public VisualEffect vfx1;
    // Start is called before the first frame update
    void Awake()
    {
        vfx1.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VFXStart1()
    {
        vfx1.Play();
    }

    public void VFXEnd1()
    {
        vfx1.Stop();
    }
}
