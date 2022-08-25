using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present2 : MonoBehaviour
{
    Rigidbody2D myPresent;
    [SerializeField] float dropSpeed = 5.0f;
    [SerializeField] float disappearLine = 1.30f;
    void Start()
    {
        myPresent = GetComponent<Rigidbody2D>();
        myPresent.velocity = new Vector2(0, -dropSpeed);
    }

    // where the present1 will disappear automatically
    void Update()
    {
        if (transform.position.y < -disappearLine)
        {
            Destroy(this.gameObject);
        }
    }
}
