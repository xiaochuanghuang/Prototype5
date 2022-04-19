using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager em;
    EnemyAnimationManager eam;
     NavMeshAgent navmeshAgent;
    public Rigidbody enemyRigidBody;

        
    public LayerMask detectionLayer;

    public float distanceFromTarget;
    public float stoppingDistance = 0.5f;
    public float rotationSpeed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        navmeshAgent.enabled = false;
        enemyRigidBody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        em = GetComponent<EnemyManager>();
        eam = GetComponent<EnemyAnimationManager>();
        navmeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyRigidBody = GetComponent<Rigidbody>();
    }
  
    public void HandleMoveToTarget()
    {
        if (em.isPerformingAction)
            return;
        Vector3 targetDirection = em.character.transform.position - transform.position;
        distanceFromTarget = Vector3.Distance(em.character.transform.position, transform.position);
        float viewAbleAngle = Vector3.Angle(targetDirection, transform.forward);
        
        if (em.isPerformingAction)
        {
            eam.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            navmeshAgent.enabled = false;

        }
        else
        {
            if(distanceFromTarget > stoppingDistance)
            {
                eam.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            }
            else if(distanceFromTarget<= stoppingDistance)
            {
                eam.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            }
        }
        HandleRotateTowardsTarget();
        navmeshAgent.transform.localPosition = Vector3.zero;
        navmeshAgent.transform.localRotation = Quaternion.identity;
    }

    private void HandleRotateTowardsTarget()
    {
        if(em.isPerformingAction)
        {
            Vector3 direction = em.character.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();
            if(direction == Vector3.zero)
            {
                direction = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed/Time.deltaTime);
        }
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(navmeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyRigidBody.velocity;

            navmeshAgent.enabled = true;
            navmeshAgent.SetDestination(em.character.transform.position);
            enemyRigidBody.velocity = targetVelocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, navmeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);
        }
      
    }
}
