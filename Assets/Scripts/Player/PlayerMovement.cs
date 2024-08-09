using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrustSpeed = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        momentumHandling();
    }

    private void momentumHandling()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.AddForce((-mousePos) * thrustSpeed);
        }

    }
}
