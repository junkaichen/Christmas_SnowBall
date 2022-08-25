using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// To Control WHERE Player2 can go
public class Boundaries2 : MonoBehaviour
{
    // private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        // Calculate the size of the Player Object
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        // restrict the map bounary for Player1
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f + objectWidth + 0.25f, 9f - objectWidth),
                                        Mathf.Clamp(transform.position.y, -8f, 8f), transform.position.z);
    }
}
