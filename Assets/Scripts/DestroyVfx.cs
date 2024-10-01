using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVfx : MonoBehaviour
{
    public float DestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyVfxXd()
    {
        Destroy(this,DestroyTime);
    }
    
}
