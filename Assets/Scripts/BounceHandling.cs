using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHandlnig : MonoBehaviour
{
    [SerializeField] private GameObject rockParticlePrefab;
    [SerializeField] private float minusThrust;
    [SerializeField] private bool badRock;
    [SerializeField] private bool heavyRock;
    [Tooltip("Lesser the heavier")]
    [SerializeField] private float howHeavy;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector2 colVel = collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity;
                if (heavyRock)
                {
                    GetComponent<Rigidbody2D>().velocity = colVel;
                }
                else
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity /= howHeavy;
                    GetComponent<Rigidbody2D>().velocity = colVel / howHeavy;
                }
                if (badRock)
                {
                    collision.gameObject.transform.parent.GetComponent<PlayerMovement>().thrustSpeed -= minusThrust;
                }
            }
            else
            {
                Vector2 colVel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = colVel;
            }
        }
        else
        {
            return;
        }
    }
}
