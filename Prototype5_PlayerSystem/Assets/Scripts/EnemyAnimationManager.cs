using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    EnemyLocomotionManager eam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        eam = GetComponentInParent<EnemyLocomotionManager>();
    }
    public void playAnimation(string targetAnim, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);

    }
    private void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        eam.enemyRigidBody.drag = 0;
        Vector3 deltaPosition = anim.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        eam.enemyRigidBody.velocity = velocity;
    }
}
