using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHandler : MonoBehaviour
{
    [SerializeField] private float getSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().thrustSpeed += getSpeed;
            collision.gameObject.transform.parent.Find("SFX").gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
