using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerComp : MonoBehaviour
{
    private Rigidbody2D rb;

    //make a var for movement speed
    public float moveSpeed;

    //make var for animator
    private Animator animator;

    // make var for jumpForce
    public float jumpForce = 100f;

    private float moveOriginal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveOriginal = moveSpeed;

        //console log vector2.up
        Debug.Log(Vector2.up);

    }

    // Update is called once per frame
    void Update()
    {
        //get input from the player
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        
        
     //if player is moving to the right set animator "isRunning" to true IF player is running to the left set animator "isRunning" to true
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("isRunning", true);
            //flip the player to the right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("isRunning", true);
            //flip the player to the left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    //make the player jump on keypress
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(Vector2.up * jumpForce);
        //     //log "i am jumping"
        //     Debug.Log("i am jumping");
        // }

        //make the player jump with a press isGrounded is true and dont let it jump if isGrounded is false.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        
        
        //disable Up input 
        if (Input.GetAxis("Vertical") > 0)
        {
            Input.ResetInputAxes();
        }

        //If user press shift key, player will run 1.5 times faster if release shift key, player will run normal speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 40f;
        }
        else
        {
            //moveSpeed wil go back to Move Speed set on inspector
            moveSpeed = moveOriginal;



        }
    }
        
        

    
}
