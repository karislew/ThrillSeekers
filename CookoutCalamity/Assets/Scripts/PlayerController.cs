using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;

    private bool isMoving;
    
    

    public Vector2 input;
    //private Animator animator;
    public LayerMask solidObjectsLayer;
    
    public Transform grabDetect;
    public Transform boxHolder;
    private PickUp pickUp;

    
    private void Awake()
    {
        instance = this;
        //animator = GetComponent<Animator>();

    }
    

    void Start()
    {
        pickUp = gameObject.GetComponent<PickUp>();
        //will prob change
        pickUp.Direction = new Vector2(0,-1);
    }
    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if(input.sqrMagnitude > .1f)
            {
                pickUp.Direction= input.normalized;
            }
           // Debug.Log("This is input.x" + input.x);
            //Debug.Log("This is input.y" + input.y);
            //whatever input is , make move that input
            
            if(input.x!=0) input.y=0;

            if (input != Vector2.zero)
            {
                
                //animator.SetFloat("moveX",input.x);
                //animator.SetFloat("moveY",input.y);
                StaminaBar.instance.UseStamina(3);
                
                

                var targetPos = transform.position;
                //var BoxtargetPos= boxHolder.transform.position;
                //var GrabtargetPos= grabDetect.transform.position;
                

                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos))
                {
                  

                    StartCoroutine(Move(targetPos));
                   
                    
        
                }

               
            }
        }
        //animator.SetBool("isMoving",isMoving);

  
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
           
           
            yield return null;
        }
       
        transform.position = targetPos;
        //grabDetect.transform.position = transform.position;
        //boxHolder.transform.position = transform.position;
       

        isMoving = false;
    }
    //three vectors, we need to pass tagret position which is a vector 3 type 
    private bool isWalkable(Vector3 targetPos)
    {   
        //if we are overlapping
        if(Physics2D.OverlapCircle(targetPos,0.1f,solidObjectsLayer)!=null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}