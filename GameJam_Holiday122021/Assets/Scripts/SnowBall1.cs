using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SnowBall1 : MonoBehaviour
{
    Rigidbody2D snowBall;
    bool isThrowed = false;
    SpriteRenderer mySpriterenderer;
    PlayerInput playerInput;
    AudioPlayer audioPlayer;
    PlayerMovement player1;
    PlayerMovement2 player2;
    ThrowDirection throwDirection;
    SnowBall2 mySnowBall2;
    DeploySnowBall deploySnowBall;
    ScoreKeeper scoreKeeper;
    Timer timer;

    Animator myAnimator;
    // Rigidbody2D myRigidbody2D;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        player1 = FindObjectOfType<PlayerMovement>();
        player2 = FindObjectOfType<PlayerMovement2>();
        throwDirection = FindObjectOfType<ThrowDirection>();
        mySnowBall2 = FindObjectOfType<SnowBall2>();
        deploySnowBall = FindObjectOfType<DeploySnowBall>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        timer = FindObjectOfType<Timer>();
        // myAnimator = FindObjectOfType<Animator>();
        // myRigidbody2D = FindObjectOfType<Rigidbody2D>();
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        snowBall = GetComponent<Rigidbody2D>();
        mySpriterenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        mySpriterenderer.enabled = false;
    }


    void OnAttack(InputValue value)
    {
        if (player1.getIsAttacking())
        {
            player1.exitAttacking();
            deploySnowBall.throwOut();
            playerInput.enabled = false;
            isThrowed = true;
            if (player1.getSnowballSize().x > 0.02f)
            {
                player1.decreaseSnowballSize();
            }
            snowBall.AddForce(throwDirection.getThrowDirection(), ForceMode2D.Force);
            snowBall.gravityScale = 0.7f;
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (!timer.CheckTimer() && player1.getIsAttacking())
        {
            mySpriterenderer.enabled = true;

        }

        if (!isThrowed)
        {
            snowBall.transform.localScale = player1.getSnowballSize();
            transform.position = throwDirection.getInitPosition();

        }

        if (player2.checkIsDead() && !mySnowBall2.checkIsThrow())
        {
            mySnowBall2.disableBall();
        }

    }



    private void OnTriggerEnter2D(Collider2D other)

    {

        if (other.tag == "Present2")
        {
            myAnimator.SetBool("isHitting", true);
            scoreKeeper.increasePlayer1Score(10);
            audioPlayer.PlayShootingClip();
            Destroy(other.gameObject);
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            Destroy(this.gameObject, 0.3f);
        }

        else if (other.tag == "BoundaryLine")
        {
            myAnimator.SetBool("isHitting", true);
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            scoreKeeper.increasePlayer1Miss();
            Destroy(this.gameObject, 0.3f);
            if (player2.getSnowballSize().x <= 0.11f)
            {
                player2.increaseSnowballSize();

            }
        }
        else if (other.tag == "Player2")
        {
            myAnimator.SetBool("isHitting", true);
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            Destroy(this.gameObject, 0.3f);
            player2.enterDead();
            player2.isAttacking = false;
            player2.canMove = true;
            player2.Invoke("exitDead", 2f);
            scoreKeeper.increasePlayer1Hit();

        }

    }

    public void disableBall()
    {
        mySpriterenderer.enabled = false;
    }

    public bool checkIsThrow()
    {
        return isThrowed;
    }
}
