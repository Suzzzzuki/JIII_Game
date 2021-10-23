using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    float speed = 1f;
    float jump = 0f;
    private Vector3 velocity;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.transform.GetComponent<Rigidbody>();
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float toward = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", accel);
        Vector3 unityChanVec = Vector3.forward * Time.deltaTime * accel * speed;
        
        //Run
        if(Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("isRun", true);
            speed = 3f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            animator.SetBool("isRun", false);
            speed = 1f;
        }
        
        //Jump
        if(Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("Jump", true);
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            animator.SetBool("Jump", false);
        }
        rb.AddForce(transform.up*jump);

        transform.Translate(unityChanVec);
        transform.Rotate(0, toward*0.4f, 0);
    }
}
