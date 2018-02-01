using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    // Use this for initialization
    private Rigidbody2D jumRigBody;

    public Sprite falling, jumping;


    public float maxLeft = -4f;
    public float maxRight = 4f;

    public float horizontalSpeed = 0.3f;
    public float jumpSpeed = 400f;

    private float lastKnownPos = 0f;
    private float lookingWay = 0.5809383f;
    
    void Start () {
        jumRigBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {


        Vector3 scale = transform.localScale;


        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > maxLeft)
        {
            
            scale.x = -lookingWay;
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxRight)
        {
            scale.x = lookingWay;
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }

        fallingOrJumping();

        transform.localScale = scale; 

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "platform")
        {
            Debug.Log("jump");
            jumRigBody.velocity = Vector3.zero;
            jumRigBody.AddForce(Vector3.up * jumpSpeed);
        }
        else
        {
            Debug.Log("player colides with something other than a platform that also has a colider");
        }
    }


    private void fallingOrJumping()
    {
        if (lastKnownPos > transform.position.y)
        {
            lastKnownPos = transform.position.y;
            this.GetComponent<SpriteRenderer>().sprite = falling;
        }
        
        if(lastKnownPos < transform.position.y)
        {
            lastKnownPos = transform.position.y;
            this.GetComponent<SpriteRenderer>().sprite = jumping;
        }
    }
}
