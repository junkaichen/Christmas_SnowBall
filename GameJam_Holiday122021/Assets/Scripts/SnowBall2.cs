using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SnowBall2 : MonoBehaviour
{
    Rigidbody2D snowBall;
    bool isThrowed = false;
    SpriteRenderer mySpriterenderer;
    PlayerInput playerInput;
    AudioPlayer audioPlayer;
    PlayerMovement player1;
    PlayerMovement2 player2;
    ThrowDirection2 throwDirection2;
    SnowBall1 mySnowBall1;
    DeploySnowBall deploySnowBall;
    ScoreKeeper scoreKeeper;
    Timer timer;

    Animator myAnimator;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        player1 = FindObjectOfType<PlayerMovement>();
        player2 = FindObjectOfType<PlayerMovement2>();
        throwDirection2 = FindObjectOfType<ThrowDirection2>();
        mySnowBall1 = FindObjectOfType<SnowBall1>();
        deploySnowBall = FindObjectOfType<DeploySnowBall>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        timer = FindObjectOfType<Timer>();
    }

    void Start()
    {
        // StartCoroutine(snowBall1Wave());
        myAnimator = GetComponent<Animator>();
        snowBall = GetComponent<Rigidbody2D>();
        mySpriterenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        mySpriterenderer.enabled = false;
    }


    void OnAttack(InputValue value)
    {
        if (player2.getIsAttacking())
        {
            player2.exitAttacking();
            deploySnowBall.throwOut2();
            playerInput.enabled = false;

            isThrowed = true;


            snowBall.AddForce(throwDirection2.getThrowDirection(), ForceMode2D.Force);

            snowBall.gravityScale = 0.7f;
        }


    }


    // Update is called once per frame
    void Update()
    {

        // if (!isThrowed)
        // {
        //     snowBall.transform.localScale = player1.getSnowballSize();
        // }
        if (player2.getIsAttacking() && !timer.CheckTimer())
        {
            mySpriterenderer.enabled = true;

        }

        if (!isThrowed)
        {
            // transform.position = target.transform.position;
            snowBall.transform.localScale = player2.getSnowballSize();
            transform.position = throwDirection2.getInitPosition();
        }

        if (player1.checkIsDead() && !mySnowBall1.checkIsThrow())
        {
            mySnowBall1.disableBall();
        }

    }



    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Present1")
        {
            myAnimator.SetBool("isHitting", true);
            scoreKeeper.increasePlayer2Score(10);
            audioPlayer.PlayShootingClip();
            Destroy(other.gameObject);
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            Destroy(this.gameObject, 0.3f);
        }
        else if (other.tag == "BoundaryLine")
        {
            myAnimator.SetBool("isHitting", true);
            scoreKeeper.increasePlayer2Miss();
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            Destroy(this.gameObject, 0.3f);

            if (player2.getSnowballSize().x > 0.02f)
            {
                player2.decreaseSnowballSize();
            }

            if (player1.getSnowballSize().x <= 0.11f)
            {
                player1.increaseSnowballSize();

            }
        }
        else if (other.tag == "Player1")
        {
            myAnimator.SetBool("isHitting", true);
            snowBall.isKinematic = true;
            snowBall.velocity = Vector3.zero;
            Destroy(this.gameObject, 0.3f);
            player1.enterDead();
            player1.isAttacking = false;
            player1.canMove = true;
            player1.Invoke("exitDead", 2f);
            scoreKeeper.increasePlayer2Hit();


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
