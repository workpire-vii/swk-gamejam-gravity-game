using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [Tooltip("The lesser the slower")]
    [SerializeField] private float scrollSpeed = 0.1f;

    [SerializeField] private GameObject GetSpeedObject;

    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        Vector2 offset = GetSpeedObject.GetComponent<Transform>().position;
        mat.mainTextureOffset = offset * scrollSpeed;
    }
}
