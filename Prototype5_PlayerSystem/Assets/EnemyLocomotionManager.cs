using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLocomotionManager : MonoBehaviour
{
    EnemyManager em;
    EnemyAnimationManager eam;
   
  

        
    public LayerMask detectionLayer;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        em = GetComponent<EnemyManager>();
        eam = GetComponent<EnemyAnimationManager>();
       
        
    }
  


}
