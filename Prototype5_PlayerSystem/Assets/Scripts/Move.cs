using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;

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
    public static int attackState = Animator.StringToHash("Attack");

    public float vert = 0.0f;
    public float hor = 0.0f;

    public MoveState _movestate;
    public IdleState _idlestate;
    public JumpState _jumpstate;
    public AttackState _attackstate;
    public DeathState _deathState;
    IState statePattern;
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
        SetState(_idlestate);
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
      
        if(Input.GetKeyDown(KeyCode.Q))
        {
            source.PlayOneShot(clip);
            SetState(_attackstate);
        }
       

        statePattern.update();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.collider.tag == "Danger")
        {
            SetState(_deathState);
            StartCoroutine(ExampleCoroutine());
          
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
