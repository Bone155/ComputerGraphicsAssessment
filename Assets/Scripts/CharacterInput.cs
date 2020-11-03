using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float gravityMulti = 2f;
    public float jumpAmount = 5f;
    public float rotateSpeed = 2f;
    public float animeSpeed = 1.5f;
    bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Forward", forward);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetBool("onGround", onGround);
        animator.speed = animeSpeed;

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
            onGround = false;
            animator.applyRootMotion = false;
        }
        else
        {
            Vector3 extraGravityForce = (Physics.gravity * gravityMulti) - Physics.gravity;
            rb.AddForce(extraGravityForce);
        }

        if (!onGround)
        {
            animator.SetFloat("Jump", rb.velocity.y);
        }
        else
        {
            animator.applyRootMotion = true;
        }

        transform.Rotate(0, horizontal * rotateSpeed, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
}
