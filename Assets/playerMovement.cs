using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }//end of start

    // Update is called once per frame
    void Update()
    {

        //make player move left and right horizontally
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

         if(Input.GetButtonDown("Jump"))
         {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
         } 


    UpdateAnimationState();
    }//end of update

    private void UpdateAnimationState()
    {
        //change anim to run left or right
        if(dirX > 0)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
            
        }
        else if(dirX < 0)
        {
            anim.SetBool("isRunning", true);
            //flip sprite
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

}//end of class
  
