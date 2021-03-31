using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psPlay : MonoBehaviour
{
    public GameObject particle;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        particle.transform.position = new Vector3(0, 0, 0);
        ps.Play();
    }
}
