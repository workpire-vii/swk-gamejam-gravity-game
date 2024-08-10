using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public float duration = 1f;
    [Tooltip("The lower the less shakier")]
    public float shakiness = 0.1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    IEnumerator Shaking()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = transform.position + (Random.insideUnitSphere * shakiness);
            yield return null;
        }
    }
}

