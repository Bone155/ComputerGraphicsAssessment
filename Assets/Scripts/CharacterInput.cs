using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public float gravityMulti = 2.0f;
    public float jumpAmount = 5.0f;
    bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Forward", Input.GetAxis("Vertical"), 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"), 0.1f, Time.deltaTime);
        animator.SetBool("onGround", onGround);

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
