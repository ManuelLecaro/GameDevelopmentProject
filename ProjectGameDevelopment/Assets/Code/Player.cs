using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Transform trans;
    public Rigidbody2D body;
    public float walkingSpeed;
    private float jumpForce = 200f;
    public Animator animator;
    private bool isFlip;
	private void Awake(){
		trans = this.trans;
	}

    // Start is called before the first frame update
    void Start()
    {
        isFlip = false;
        escomida = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                isFlip = false;
                Vector3 theScale = trans.localScale;
		        if(!isFlip){
                    theScale.x = Mathf.Abs(theScale.x);
	        	    trans.localScale = theScale;
                }

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 theScale = trans.localScale;
                isFlip = true;
		        if(isFlip){
                    theScale.x = -1*Mathf.Abs(theScale.x);
	        	    trans.localScale = theScale;
                }
                speed += walkingSpeed;
            }
            v.x = speed;
            body.velocity = v;
            animator.SetFloat("Speed",speed);
                    //animator.SetBool("Escomida",false);
        }
    }

}
