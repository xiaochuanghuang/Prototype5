using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public  bool isPerformingAction;
    EnemyLocomotionManager elm;
    [Header("AI Settings")]
    public float detectionRadius = 20;
    public float minimumDetectionAngle = -50f;
    public float maximumDetectionAngle = 50f;
    void Start()
    {
        
    }
    private void Awake()
    {
        elm = GetComponent<EnemyLocomotionManager>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        handleCurrentAction();
    }
    void handleCurrentAction()
    {
        if(elm.character == null)
        {
            elm.HandleDetection();
        }
        else
        {
            elm.HandleMoveToTarget(); 
        }
    }
}
