using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    // create a value to store the User input direction (Pressing Up or Down and etc)
    Vector2 moveInput;

    // create a value to store the reference (from Unity Component)
    Rigidbody2D myRigidbody;

    // create a value to adjust the speed of the horizontal movement
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float SnowballIncreaseValue = 0.005f;
    [SerializeField] float SnowballDecreaseValue = 0.001f;

    // create a value to store the reference (from Unity Component)
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    PlayerInput myPlayerInput;

    private bool isDead;
    public bool isAttacking = false;
    public bool canMove = true;

    public Vector3 mySnowBallSize = new Vector3(0.02f, 0.02f, 0.02f);
    public int maxSnowBallSize = 0;
    public int tempSnowBallSize = 0;


    void Start()
    {
        // caching a reference to rigid body component, so we can access or change it
        myRigidbody = GetComponent<Rigidbody2D>();

        // caching a reference to Animator Component, so we can access or change it
        myAnimator = GetComponent<Animator>();

        myCapsuleCollider = GetComponent<CapsuleCollider2D>();

        myPlayerInput = GetComponent<PlayerInput>();

        // InitBounds();
    }


    void Update()
    {
        Walk();
        // FlipSprite();
    }


    // This method will be called when user press keyboard and the information will be send from User,
    void OnMove(InputValue value)
    {
        // And we want to store the direction information
        moveInput = value.Get<Vector2>();
    }

    void OnEnterAttack(InputValue value)
    {
        if (value.isPressed)
        {
            myAnimator.SetBool("isWalking", false);
            reenterAttacking();
        }
    }

    // if the User press jump, it will call this methods
    void OnJump(InputValue value)
    {
        if (value.isPressed && myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            // only need to change the Y directions by adding(because is go up) the jumpSpeed
            // Need to consider the Gravity, so we add a value into original value
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    // define how the character moves based on what the player input is
    void Walk()
    {
        if (canMove)
        {
            // first parameter is the movement, second parameter is keep the current gravity
            Vector2 playerVelocity = new Vector2(moveInput.x * walkSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;

            if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon)
            {
                myAnimator.SetBool("isWalking", true);
                if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon)
                {
                    // only change the horizontal(x) direction
                    transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
                }
            }
            else
            {
                myAnimator.SetBool("isWalking", false);
            }
        }
    }


    // void FlipSprite()
    // {
    //     // Set up the condition when to flip the character
    //     // if the User press something, the left side will have a value which must greater than Epilson (we don't use 0 here to prevent bug)
    //     if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon)
    //     {
    //         Debug.Log("turn");
    //         // only change the horizontal(x) direction
    //         transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    //     }
    // }


    public void exitAttacking()
    {
        myAnimator.SetBool("isAttacking", true);
        isAttacking = false;
        canMove = true;
        Invoke("stopAttackingAnimation", 0.5f);
    }

    public bool getIsAttacking()
    {
        return isAttacking;
    }

    public void reenterAttacking()
    {
        isAttacking = true;
        canMove = false;
    }

    void stopAttackingAnimation()
    {
        myAnimator.SetBool("isAttacking", false);
    }

    public void enterDead()
    {
        isDead = true;
        myAnimator.SetBool("isDead", true);
        myPlayerInput.enabled = false;

    }

    public void exitDead()
    {
        isDead = false;
        myAnimator.SetBool("isDead", false);
        myPlayerInput.enabled = true;
    }

    public bool checkIsDead()
    {
        return isDead;
    }

    public void increaseSnowballSize()
    {
        if (tempSnowBallSize < 27)
        {
            tempSnowBallSize++;
            if (tempSnowBallSize > maxSnowBallSize)
            {
                maxSnowBallSize = tempSnowBallSize;
            }
        }
        mySnowBallSize += new Vector3(SnowballIncreaseValue, SnowballIncreaseValue, SnowballIncreaseValue);
    }

    public void decreaseSnowballSize()
    {
        if (tempSnowBallSize > 0)
        {
            tempSnowBallSize--;
        }
        mySnowBallSize -= new Vector3( SnowballDecreaseValue,  SnowballDecreaseValue,  SnowballDecreaseValue);
    }


    public Vector3 getSnowballSize()
    {
        return mySnowBallSize;
    }

    public int getMaxSnowballSize()
    {
        return maxSnowBallSize;
    }
}