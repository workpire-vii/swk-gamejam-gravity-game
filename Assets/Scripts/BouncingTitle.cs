using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingTitle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    private Vector3 startpos;

    void Start()
    {
        startpos = transform.position;
    }

    void Update()
    {
        Vector3 pos = startpos;
        pos.y = height * (Mathf.Sin(Time.time * speed)) + startpos.y;

        transform.position = pos;
    }
}
