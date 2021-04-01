using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 7f;

    float gravity = -20f;

    public float JumpPower = 10f;

    public float yVelocity = 0;

    float hp;

    bool isJumping = false;

    CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void DamageAction(int damage)
    {
        hp -= damage;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0;
            isJumping = false;
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = JumpPower;
            isJumping = true;
        }

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = gameObject.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        

        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
