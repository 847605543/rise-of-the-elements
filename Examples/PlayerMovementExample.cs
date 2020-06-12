/*
	Example of a player movement script for Rigidbody2D object using Animator for animations.
	Animator uses parameters Horizontal, Vertical, and Speed.	

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement; //x and y position

    //Start is called before the first frame update
    
    /*
    void Start()
    {
        
    }
    */

    //Update is called once per frame
    //framerate can fluctuate, not a good place to put physics-related things

    void Update()
    {
        // input
	movement.x = Input.GetAxisRaw("Horizontal"); //returns a value between -1 and 1 (left and right)
	movement.y = Input.GetAxisRaw("Vertical"); //returns a value between -1 and 1 (down and up)
	
	//updating the animator controller parameters
	//we can add a conditional statement here when we add more idle animations for different directions
	animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
	animator.SetFloat("Speed", movement.sqrMagnitude); //just for example, should be normalized

    }

    void FixedUpdate(){
     
        //movement
    	rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //Time.fixedDeltaTime smooths the player movement
    
    }

}
