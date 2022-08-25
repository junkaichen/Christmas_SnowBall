using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// To Control WHERE Player1 can go
public class Boundaries : MonoBehaviour
{

    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        // Calculate the size of the Player Object
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }


    // restrict the map bounary for Player1
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f + objectWidth, 0f - objectWidth - 0.25f), 
                                                    Mathf.Clamp(transform.position.y, -8f, 8f), transform.position.z);
    }
}
