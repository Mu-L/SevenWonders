using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移动跳跃
    public float runSpeed;
    public float jumpSpeed;  

    private Rigidbody2D myRigidbody;
    private bool isGround;
    private BoxCollider2D myFeet;
    private bool isOneWayPlatform;
    private VirtualGun vg;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        vg = GameObject.Find("VirtualGun").GetComponent<VirtualGun>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        Flip();
        Run();
        Jump();        
    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (myRigidbody.velocity.x < -0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

        }
    }

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal"); //value is between -1 to 1
        Vector2 playerVelocity = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
    }

    void Jump()
    {
        if (isGround)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVelocity;
                vg.Shoot3();
            }
        }

    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("Platform"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("LevelPass"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("DestructibleLayer"))
                || myFeet.IsTouchingLayers(LayerMask.GetMask("Items"));
        isOneWayPlatform = myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }
}
