using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDirection2 : MonoBehaviour
{
    public GameObject target;
    public float speed = 15;
    public Vector3 direction = Vector3.up;
    bool isForward = true;
    SpriteRenderer mySpriterenderer;
    Vector2 targetDirection;

    Vector3 initPosition;

    void Start()
    {
        mySpriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

        targetDirection = transform.up;

        transform.position = target.transform.position + new Vector3(-0.3f, 0.3f, 0);

        initPosition = transform.position;


        float correctAngle = CheckAngle(StandardRot(transform.localEulerAngles.z));

        if (correctAngle < 0f)
        {
            isForward = false;
        }
        if (correctAngle > 90f)
        {
            isForward = true;
        }

        if (isForward)
        {
            transform.RotateAround(target.transform.position, -direction, speed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(target.transform.position, direction, speed * Time.deltaTime);
        }
        if (FindObjectOfType<PlayerMovement2>().getIsAttacking())
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
