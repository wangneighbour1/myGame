using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health;
    public float Speed;
    public float jumpSpeed;
    public int jumpMaxNum;
    private Rigidbody2D myRigidbody2D;
    private BoxCollider2D myFeet;
    private Animator myAnim;

    private int jumpNum;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        jumpNum = jumpMaxNum;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        switchAnimation ();
        CheckGround();
    }

    void CheckGround(){
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    // void attack1(){
    //     attack1cd -= Time.deltaTime;
    //     if(Input.GetMouseButtonDown(0) && attack1cd<=0){
    //         myAnim.SetTrigger("attack1");
    //         attack1cd = 0.4f;
    //     }
    // }

    void Run(){
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * Speed,myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run",(playerHasXAxisSpeed&isGround));
    }
    void Flip(){
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed){
            if(myRigidbody2D.velocity.x>0.1f){
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            else if(myRigidbody2D.velocity.x<-0.1f){
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }

    void Jump(){
        if(Input.GetKeyDown("space")){
            if(isGround){
                jumpNum = jumpMaxNum;
            }
            if( jumpNum >0 ){
                myAnim.SetBool("jump",true);
                myAnim.SetBool("fall",false);
                Vector2 jumpVel = new Vector2(myRigidbody2D.velocity.x,jumpSpeed);
                myRigidbody2D.velocity = jumpVel;
                jumpNum -- ;
            }
        }
    }

    void switchAnimation ()
    {
        
        myAnim.SetBool("idle",false);
        if(myAnim.GetBool("jump")){
            if(myRigidbody2D.velocity.y<0.0f){
                myAnim.SetBool("jump",false);
                myAnim.SetBool("fall",true);
            }
        }
        else if(isGround){
            myAnim.SetBool("fall",false);
            myAnim.SetBool("idle",true);
        }
    }
}
