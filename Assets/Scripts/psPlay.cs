using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psPlay : MonoBehaviour
{
    
    ParticleSystem ps;
    // Start is called before the first frame 

    // Update is called once per frame
    void Update()
    { 
        ps.Play();
    }
}
