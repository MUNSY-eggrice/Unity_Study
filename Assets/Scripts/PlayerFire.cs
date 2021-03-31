using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //발사위치
    public GameObject fireposition;
    //발사 오브젝트0
    public GameObject bombFactory;

    public float throwPower = 15f;

    public GameObject bulletEffect;

    ParticleSystem ps;

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = fireposition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();

            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                print("raycast hit!");
                Debug.Log(hitInfo.collider);
                Debug.Log(hitInfo.point);
                

                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);

                // bulletEffect.transform.position = hitInfo.point;
                bulletEffect.transform.position = new Vector3(1, 0, 1);
                ps.Play();
            }
        }
    }
}
