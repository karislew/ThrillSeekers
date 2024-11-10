using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
   // Start is called before the first frame update


   //setting public move speed variable
   public float moveSpeed= 5f;


   //getting rigid body which will help move player
   public Rigidbody2D rb;
   private Animator animator;
   private bool isMoving;


   //storing the (x,y) input
   Vector2 movement;
   private InputAction move;
     private InputAction dash;   
     private InputAction fire;
   //name of script
   public PlayerInputActions playerControls;


   //reference to pickup script
   private SiblingPickUp pickUp;


   private float dashPower = 24f;
   private float dashCooldown= 1f;
   private bool canDash = true;
   private bool isDashing;
   private float dashingTime = .1f;








   // Update is called once per frame




   private void Awake()
   {
       animator = GetComponent<Animator>();
       playerControls= new PlayerInputActions();
   }
   private void OnEnable()
   {
      
       move=playerControls.Player.Move;
       move.Enable();
       dash = playerControls.Player.Dash;
       dash.Enable();


    
   }
   private void OnDisable()
   {
  
       //requirement of new input system
       dash.Disable();
       move.Disable();
   }
   void Start ()
   {
       //find pickup component
       pickUp= gameObject.GetComponent<SiblingPickUp>();
       //setting diretion
       pickUp.Direction= new Vector2(0,-1);
   }
   void Update()
   {
       if(isDashing)
       {
           return;
       }
       bool dashPressed = dash.triggered;
       //input


       //storing horizontal movement (-1,1)->left,right
       //movement.x = Input.GetAxisRaw("Horizontal");
       //storing the vertical movement (-1,1)-> down,up
       //movement.y = Input.GetAxisRaw("Vertical");
       movement = move.ReadValue<Vector2>();
      
       animator.SetFloat("Speed", movement.sqrMagnitude);
       if(movement!=Vector2.zero)
       {
           animator.SetFloat("Horizontal",movement.x);
           animator.SetFloat("Vertical",movement.y);


       }
       if(dashPressed && canDash)
       {
           StartCoroutine(Dash());




       }
          
          
          
      
      
       //animator.SetFloat("Speed",movement.sqrMagnitude);
       //check we dont store zero as our direction
       if(movement.sqrMagnitude > .1f)
       {
           //will always be one
           pickUp.Direction = movement.normalized;


       }
      
   }


   void FixedUpdate()
   {
       if(isDashing)
       {
           return;
       }
       //actual movement
       //moves rigid body to new position
       //current position plus movement
       //multiple by time to get a constant movement speed
       rb.MovePosition(rb.position + movement * moveSpeed *  Time.fixedDeltaTime);
   }


   IEnumerator Dash()
   {
       canDash = false;
       isDashing =true;
       rb.MovePosition(rb.position + movement * dashPower * moveSpeed * Time.fixedDeltaTime);
       Debug.Log("DASHINGG");
       yield return new WaitForSeconds(dashingTime);
       isDashing= false;
       yield return new WaitForSeconds(dashCooldown);
       canDash=true;
   }


  
}
