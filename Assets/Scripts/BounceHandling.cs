using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHandlnig : MonoBehaviour
{
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector2 colVel = collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = colVel;
                Debug.Log("Works!!! " + colVel);
            }
            else
            {
                Vector2 colVel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = colVel;
                Debug.Log("Works!!! " + colVel);
            }
        }
        else
        {
            return;
        }
    }
}
