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

    //public GameObject ps;
    public GameObject ps;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
       
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

            RaycastHit rayhit = new RaycastHit();

            if(Physics.Raycast(ray, out rayhit,Mathf.Infinity))
            {

                Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
                GameObject clone = Instantiate(ps, rayhit.point, Quaternion.LookRotation(rayhit.normal));
                Destroy(clone, 2f);
               

            }
        }
    }
}
