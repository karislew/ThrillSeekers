using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class GrabController : MonoBehaviour
{

    // Start is called before the first frame update
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    private bool isPressed;
   

    // Update is called once per frame
   
    private float x;
    private float y;

    
    // Start is called before the first frame update
   
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        //have to change to face characters direction
        Vector2 direction_player= new Vector2(x,y);
        

        RaycastHit2D grabCheck= Physics2D.Raycast(grabDetect.position,direction_player * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag=="Box")
        {
            if(Input.GetKey(KeyCode.G))
            {
                Debug.Log("Direction the player is facing for raycast " +  direction_player);
                //isPressed=true;
                //changing parent allows you to have the "box" object move to the location of the boxHolder 
                grabCheck.collider.gameObject.transform.parent= boxHolder;
                //Debug.Log("Game Objecy " + gameObject);
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                

            
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent=null;
                
           
            }
        }
        Debug.DrawRay(grabDetect.position,direction_player * rayDist);
        
        
    }
    
}
