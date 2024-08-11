using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoleHandling : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intensityText;

    public Transform playerTransform;
    Rigidbody2D playerRB;
    public float influenceRange;
    public float intensity;
    public float rockintensity;
    private float distance;
    Vector2 pullForce;
    public GameObject loseTab;
    public float difAcel;
    private float difficulty;
    private float finalIntense;

    void Start()
    {
        playerRB = playerTransform.GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
        difficulty = 0;
        finalIntense = 0;
    }


    void FixedUpdate()
    {
        if (!GameHandler.Pause)
        {
            difficulty += difAcel;
            finalIntense = difficulty + intensity;
            intensityText.text = finalIntense.ToString();
        }

        distance = Vector2.Distance(playerTransform.position, transform.position);
        if (distance <= influenceRange)
        {
            pullForce = (new Vector2(transform.position.x, transform.position.y) - playerRB.position).normalized * distance * finalIntense;
            playerRB.AddForce(pullForce, ForceMode2D.Force);
        }

        foreach (Transform childTransform in this.transform)
        {
            if (childTransform.CompareTag("Debree"))
            {
                pullForce = (new Vector2(transform.position.x, transform.position.y) - new Vector2(childTransform.position.x, childTransform.position.y)).normalized * rockintensity;
                childTransform.GetComponent<Rigidbody2D>().AddForce(pullForce, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Debree"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            loseTab.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
