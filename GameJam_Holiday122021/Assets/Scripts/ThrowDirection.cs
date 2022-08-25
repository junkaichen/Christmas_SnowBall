using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ThrowDirection : MonoBehaviour
{
    public GameObject target;
    [SerializeField] float Speed = 60;
    public Vector3 direction = Vector3.up;
    bool isForward = true;
    SpriteRenderer mySpriterenderer;
    Vector2 targetDirection;
    Vector3 initPosition;
    bool random = false;

    void Start()
    {
        mySpriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        targetDirection = transform.up;

        transform.position = target.transform.position + new Vector3(0.3f, 0.3f, 0);

        initPosition = transform.position;


        float correctAngle = CheckAngle(StandardRot(transform.localEulerAngles.z));

        if (correctAngle < -90f)
        {
            isForward = false;
        }
        if (correctAngle > 0f)
        {
            isForward = true;
        }

        if (isForward)
        {
            if (!random)
            {
                transform.RotateAround(target.transform.position, -direction, Speed * Time.deltaTime * 60);
                random = true;
            }
            else
            {
                transform.RotateAround(target.transform.position, -direction, Speed * Time.deltaTime);
            }

        }
        else
        {
            transform.RotateAround(target.transform.position, direction, Speed * Time.deltaTime);
        }

        // Entering the Attacking mode
        if (FindObjectOfType<PlayerMovement>().getIsAttacking())
        {
            mySpriterenderer.enabled = true;

        }
        else
        {
            mySpriterenderer.enabled = false;
        }


    }


    public float CheckAngle(float value)


    {
        float angle = value - 180;
        if (angle > 0)
            return angle - 180;






        return angle + 180;


    }

    private float StandardRot(float value)
    {
        if (value > 180)
        {
            value -= 360;
        }

        return Mathf.Round(value * 100) / 100;
    }

    public Vector2 getThrowDirection()
    {
        return targetDirection;
    }

    public Vector3 getInitPosition()
    {
        return initPosition;
    }

}
