using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.VFX;
using UnityEngine.VFX;
public class VFXActivate : MonoBehaviour
{
    public VisualEffect vfx;
    // Start is called before the first frame update
    void Awake()
    {
        vfx.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VFXStart()
    {
        vfx.Play();
    }

    public void VFXEnd()
    {
        vfx.Stop();
    }
}
