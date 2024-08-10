using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float thrustSpeed = 1;

    [NonSerialized] public float speed;

    [SerializeField] private ParticleSystem snow;
    [SerializeField] private TextMeshProUGUI scoreSpeed;
    [SerializeField] private TextMeshProUGUI thrust;


    [Header("SFX Stuff")]
    [SerializeField] private AudioClip extinguisherStart;
    [SerializeField] private AudioClip extinguisherLoop;
    [SerializeField] private AudioClip extinguisherEnd;
    [SerializeField] private AudioSource audioSourceLoop;
    private AudioSource audioSourceStart;


    // Variable to access internal stuff
    private Rigidbody2D rb;
    ParticleSystem.EmissionModule emission;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSourceStart = GetComponent<AudioSource>();
        emission = snow.emission;
    }

    void Update()
    {
        updateScore();
        InputAudio();
    }

    private void FixedUpdate()
    {
        momentumHandling();
        limit();
    }

    private void updateScore()
    {
        speed = rb.velocity.magnitude;
        scoreSpeed.text = speed.ToString();

        thrust.text = thrustSpeed.ToString();
    }
    private void momentumHandling()
    {
        if (Input.GetMouseButton(0))
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

    private void InputAudio()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSourceStart.clip = extinguisherStart;
            audioSourceStart.Play();
            audioSourceLoop.PlayScheduled(extinguisherStart.length);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            audioSourceStart.clip = extinguisherEnd;
            audioSourceStart.Play();
            audioSourceLoop.Stop();
        }
    }

    private void limit()
    {
        if (transform.position.x > 150)
            transform.position = new Vector3(150, transform.position.y, transform.position.z);
        if (transform.position.y > 150)
            transform.position = new Vector3 (transform.position.x, 150, transform.position.z);
    }
}
