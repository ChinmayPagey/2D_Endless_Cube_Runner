using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //Chinmay Pagey (20MIA1112)
    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeScroll myChallengeScroller;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        myChallengeScroller = GameObject.FindObjectOfType<ChallengeScroll>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)&&isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
        if (transform.position.x < posX)
        {
            GameOver();
        }
    }

    void Update()
    {

    }
    void GameOver()
    {
        isGameOver = true;
        myChallengeScroller.GameOver();

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag=="Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
