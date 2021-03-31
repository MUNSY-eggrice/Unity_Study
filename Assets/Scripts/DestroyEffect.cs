using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{

    public float destroyTime = 1.5f;

    float currentTime = 0;
    void Update()
    {
        if (destroyTime < currentTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}
