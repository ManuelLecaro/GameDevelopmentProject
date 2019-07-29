using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Transform trans;
    public Rigidbody2D body;
    public float walkingSpeed;
    private float jumpForce = 200f;
    private bool isFlip;
    public float jumpTime;
    public float jumpTimeCounter;
    /*this bool is to tell us whether you are on the ground or not
     * the layermask lets you select a layer to be ground; you will need to create a layer named ground(or whatever you like) and assign your
     * ground objects to this layer.
     * The stoppedJumping bool lets us track when the player stops jumping.*/
    public bool grounded;
    public LayerMask whatIsGround;
    public bool stoppedJumping;

    /*the public transform is how you will detect whether we are touching the ground.
     * Add an empty game object as a child of your player and position it at your feet, where you touch the ground.
     * the float groundCheckRadius allows you to set a radius for the groundCheck, to adjust the way you interact with the ground*/

    public Transform groundCheck;
    public float groundCheckRadius;

    private void Awake(){
    trans = this.trans;
	}

    // Start is called before the first frame update
    void Start()
    {
        isFlip = false;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        //if we are grounded...
        if (grounded)
        {
            //the jumpcounter is whatever we set jumptime to in the editor.
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { // x-axis movement
            body.AddForce(new Vector2(0f, jumpForce));
        }

        { // x-axis movement
            var v = body.velocity;
            var speed = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed += -walkingSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
        }
    }
    private void OnCollisionEnter2D(Collision2D colisionar)
    {
        var newObject = colisionar.collider.gameObject;
        if (newObject.tag == "Comida")
        {
            var scala = this.transform.localScale;
            if (scala.y < 0.7f)
            {
                scala.y *= 1.5f;
                this.transform.localScale = scala;
            }
            newObject.SetActive(false);
        }
   }

    void FixedUpdate()
    {
        //I placed this code in FixedUpdate because we are using phyics to move.

        //if you press down the mouse button...
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //and you are on the ground...
            if (grounded)
            {
                //jump!
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        //if you keep holding down the mouse button...
        if (Input.GetKeyDown(KeyCode.UpArrow) && !stoppedJumping)
        {
            //and your counter hasn't reached zero...
            if (jumpTimeCounter > 0)
            {
                //keep jumping!
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        //if you stop holding down the mouse button...
        if (Input.GetMouseButtonUp(0))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

}

