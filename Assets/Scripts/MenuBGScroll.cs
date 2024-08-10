using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MenuBGScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        mat.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
