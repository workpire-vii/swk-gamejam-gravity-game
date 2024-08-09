using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrustSpeed = 1;
    [SerializeField] private TextMeshProUGUI scoreSpeed;
    [NonSerialized] public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        updateScore();
    }

    private void FixedUpdate()
    {
        momentumHandling();
    }

    private void updateScore()
    {
        speed = Vector2.SqrMagnitude(rb.velocity);
        scoreSpeed.text = speed.ToString();
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
