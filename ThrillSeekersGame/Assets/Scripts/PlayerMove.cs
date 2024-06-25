using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //will set the speed for movement 
    public float speed= 5.0f;
    //how high player can jump 
    public float jumpForce = 5;
    //check if the player is on the ground 
  
    
    //using to get the horizontal and veritcal movement (moves right-left, forward-backward)
    private float horizontalInput;
    private float forwardInput;
    //need access to rigidbody to make it move up 
    private Rigidbody playerRb;

    
    // Start is called before the first frame update
    //starts code whenever game starts and runs it one time 
    void Start()
    {   
        //getting access to rigidbody
        playerRb=GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame

    void Update()
    {   
        //get player input
        horizontalInput= Input.GetAxis("Horizontal");
        forwardInput= Input.GetAxis("Vertical");

        //changes the position (by using the Transform position component)
        //vector3 forward (get position 0,0,1 (working on the Z axis))
        //forward input will be pos or neg (forward or backward)
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Vector3 right- changes the x axis
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        //jump function 
        //if the space button has been pressed
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            //access the players rigidbody - adding force (vector up which is the y axis), impulse- applies the force immediately
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           
        }
    }

    bool isGrounded()
    {
        //getting the ground layer and assigning it to layerMask variable 
        int layerMask = LayerMask.GetMask("Ground");
        Vector3 offset = new Vector3(0.0f, -0.5f, 0.0f);
        return Physics.Raycast(transform.position + offset, Vector3.down, 
            0.6f, layerMask);
    }


}
