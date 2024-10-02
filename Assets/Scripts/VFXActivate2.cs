using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class VFXActivate2 : MonoBehaviour
{
    public VisualEffect vfx2;
    // Start is called before the first frame update
    void Awake()
    {
        vfx2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VFXStart2()
    {
        vfx2.Play();
    }

    public void VFXEnd2()
    {
        vfx2.Stop();
    }
}
