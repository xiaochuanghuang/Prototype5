using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    

    public AudioSource source;
    public AudioClip clip;
    public Inventory inventory;
    public Transform bodyTransform { get; set; }
    public Rigidbody rigidBody { get; set; }
    public Animator bodyAnimator { get; set; }

    public float walkSpeed = 0.1f;
    public float rotateSpeed = 0.001f;
    public float rotateForce = 0.01f;

   public AnimatorStateInfo states;
    static int idleState = Animator.StringToHash("Idle");
    static int moveState = Animator.StringToHash("Walk");
   public static int JumpState = Animator.StringToHash("Jump");
    public static int attackState = Animator.StringToHash("Attack01");
    public static int attack2State = Animator.StringToHash("Attack02");

    public float vert = 0.0f;
    public float hor = 0.0f;

    public MoveState _movestate;
    public IdleState _idlestate;
    public JumpState _jumpstate;
    public AttackState _attackstate;
    public Attack2State _attack2state;
    public DeathState _deathState;
    IState statePattern;
    public InventoryUI inventoryUI;
    bool InventoryOn;
    bool PickItemOn;
    Iitems item;
    // Start is called before the first frame update
    void Start()
    {
        bodyTransform = this.GetComponent<Transform>();
        rigidBody = this.GetComponent<Rigidbody>();
        bodyAnimator = this.GetComponent<Animator>();

        _idlestate = new IdleState(this);
        _movestate = new MoveState(this);
        _jumpstate = new JumpState(this);
        _attackstate = new AttackState(this);
        _deathState = new DeathState(this);
        _attack2state = new Attack2State(this);
        SetState(_idlestate);
        InventoryOn = false;
        PickItemOn = false;
    }
    private void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        states = bodyAnimator.GetCurrentAnimatorStateInfo(0);
        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetState(_jumpstate);
        }
        if (Input.GetMouseButtonDown(1))
        {
           // source.PlayOneShot(clip);
            SetState(_attack2state);
        }

        if (Input.GetMouseButtonDown(0))
        {
           // source.PlayOneShot(clip);
            SetState(_attackstate);
        }
       

        statePattern.update();

        if(Input.GetKeyDown(KeyCode.Tab))
        {
         if( InventoryOn == false)
            {
                GameObject.Find("InventoryUI").GetComponent<Canvas>().enabled = true;
                InventoryOn = true;

            }
        else 
            {
                GameObject.Find("InventoryUI").GetComponent<Canvas>().enabled = false;
                InventoryOn = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.F)&& PickItemOn == true)
        {
            inventory.addItem(item);

        }
       
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      
    }

    
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.collider.tag == "Danger")
        {
            SetState(_deathState);
            StartCoroutine(ExampleCoroutine());
          
        }

        if (collision.collider.tag == "PickUp" )
        {
           
            
            item = collision.collider.GetComponent<Iitems>();
            if (item != null)
            {
                PickItemOn = true;
                Debug.Log(item);
              
            }
            //GameObject.Find("InventoryUI").transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;

        }
     
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "PickUp")
        {
            PickItemOn = false;
        }
    }

    public void SetState(IState s)
    {
        statePattern = s;
        statePattern.OnStateBegin();
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("SimpleNaturePack_Demo");

    }

}
