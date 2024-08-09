using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrustSpeed = 1;

    [SerializeField] private ParticleSystem snow;
    [SerializeField] private TextMeshProUGUI scoreSpeed;


    ParticleSystem.EmissionModule emission;
    [NonSerialized] public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        emission = snow.emission;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        updateScore();
        momentumHandling();
    }

    private void updateScore()
    {
        speed = rb.velocity.magnitude;
        scoreSpeed.text = speed.ToString();
    }
    private void momentumHandling()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            emission.enabled = true;
            snow.Play();
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.AddForce((new Vector2(transform.position.x, transform.position.y) - mousePos) * thrustSpeed);
        }
        else
        {
            emission.enabled = false;
            snow.Stop();
        }
    }
}
