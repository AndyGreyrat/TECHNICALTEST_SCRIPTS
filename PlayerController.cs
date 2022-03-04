using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float HorizontalMove;
    private float VerticalMove;
    private Vector3 PlayerInput;
    public CharacterController Player;
    public Animator PlayerAnimatorController;
    private Vector3 movePlayer;
    public float JumpForce;
    public float gravity = 9.81f;
    public float FallVelocity;
    public Transform Camera;
    private Vector3 camForward;
    private Vector3 camRight;
    float Move;
    public Rigidbody RB;
    public bool canAttack;
    public int Speed;
    public bool IsAttacking;
    public float PunchImpulse;
    public bool InAttack = false;                                                               
    public float  VerticalSpeed;
    public int PlayerLevel;
    public ActiveWeapon ActiveSword;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
        PlayerAnimatorController = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (ControllerDialogos.INconversation)
            return;
        Move = (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * 2) * Speed * Time.deltaTime;
        Move = Mathf.Abs(Move);
        if (Move != 0)
        {
            Vector3 Rotation = transform.eulerAngles ;
            Rotation.y = Camera.eulerAngles.y ;
            transform.eulerAngles = Rotation ;
        }
        HorizontalMove = Input.GetAxis("Horizontal");
        VerticalMove = Input.GetAxis("Vertical");
        PlayerInput = new Vector3(HorizontalMove, 0, VerticalMove);
        movePlayer = PlayerInput.x * camRight + PlayerInput.z * camForward;
        movePlayer = movePlayer * Speed;
        Player.transform.LookAt(Player.transform.position + movePlayer);
        SetGravity();
        CamDirection();
        PlayerSkills();
        PlayerInput = Vector3.ClampMagnitude(PlayerInput, 1);
        Player.Move(movePlayer * Time.deltaTime);
        PlayerAnimatorController.SetFloat("PlayerSpeed", PlayerInput.magnitude * Speed);
        if (RingMenu.InDancing == true)
            return;
        if (Input.GetKeyDown(KeyCode.Mouse1) && InAttack == false )
        {
            PlayerAnimatorController.SetBool("InAttack", true);
            PlayerAnimatorController.SetTrigger("Attack");
            if (GetComponent<TakeWeapon>().ActiveSword == true)
            {
                PlayerAnimatorController.SetBool("SwordActive", true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerAnimatorController.SetBool("InAttack", false);
            PlayerAnimatorController.SetBool("SwordActive", false);
        }
        
    }
    

    //funcion que permite determinar la direccion a la que mira la camara.
    public void CamDirection()
    {
        camForward = Camera.transform.forward;
        camRight = Camera.transform.right;
        camForward.y = 0; 
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    //Funcion para saltar y darle otras acciones al personaje.
    public void PlayerSkills()
    {
        if (ControllerDialogos.INconversation)
            return;
       if (Player.isGrounded && Input.GetButtonDown("Jump"))
       {
            FallVelocity = JumpForce;
            movePlayer.y = FallVelocity;
            PlayerAnimatorController.SetTrigger("PlayerJump");
       }
       
    }
    //Funcion para la gravedad en el personaje.
    public void SetGravity()
    {
        if (Player.isGrounded)
        {
            FallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = FallVelocity;
        }
        else
        {
            FallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = FallVelocity;
            PlayerAnimatorController.SetFloat("PlayerVerticalSpeed", Player.velocity.y);
        }
        PlayerAnimatorController.SetBool("IsGrounded", Player.isGrounded);
       
    }   
    private void OnAnimatorMove()
    {
        
    }
    void OnTriggerEnter(Collider Coll)
    {
        if(Coll.CompareTag ("PUNCH"))
        {
            LIfeAndDamage.Life -= PunchMonster.damage;
        }
    }
    public void EndAnimationsAttack()
    {
        PlayerAnimatorController.SetBool("InAttack", false);
        InAttack = false;
    }

}   

 

     
