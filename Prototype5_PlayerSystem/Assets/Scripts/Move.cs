using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform bodyTransform;
    private Rigidbody rigidBody;
    private Animator bodyAnimator;
    public float walkSpeed = 0.1f;
    public float rotateSpeed = 0.001f;
    public float rotateForce = 0.01f;

    AnimatorStateInfo states;
    static int idleState = Animator.StringToHash("Idle");
    static int moveState = Animator.StringToHash("Walk");
    static int JumpState = Animator.StringToHash("Jump");
    static int attackState = Animator.StringToHash("Attack");
    // Start is called before the first frame update
    void Start()
    {

        bodyTransform = this.GetComponent<Transform>();
        rigidBody = this.GetComponent<Rigidbody>();
        bodyAnimator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        states = bodyAnimator.GetCurrentAnimatorStateInfo(0);
        float vert = Input.GetAxis("Vertical");

        float hor = Input.GetAxis("Horizontal");

        if(vert  > 0.1f)
        {
            bodyAnimator.SetBool("Walk", true);
        }
        else
        {
            bodyAnimator.SetBool("Walk", false);

        }

        bodyTransform.Translate(new Vector3(0, 0, 0.1f) * Time.deltaTime * walkSpeed * vert);
        bodyTransform.Rotate(new Vector3(0, 0.0000000001f, 0), hor * rotateSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector3(0, 2, 0) * rotateForce);
            bodyAnimator.SetBool("Jump", true);
            
        }
        if(states.shortNameHash == JumpState)
        {
            if(!bodyAnimator.IsInTransition(0))
            {
                bodyAnimator.SetBool("Jump", false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            bodyAnimator.SetBool("Attack", true);
        }
        if (states.shortNameHash == attackState)
        {
            if (!bodyAnimator.IsInTransition(0))
            {
                bodyAnimator.SetBool("Attack", false);
            }
        }


    }
}
