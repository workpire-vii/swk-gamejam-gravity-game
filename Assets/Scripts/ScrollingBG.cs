using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] private GameObject GetSpeedObject;

    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        Vector2 offset = GetSpeedObject.GetComponent<Transform>().position;
        mat.mainTextureOffset = offset;
    }
}
