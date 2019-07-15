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

}
