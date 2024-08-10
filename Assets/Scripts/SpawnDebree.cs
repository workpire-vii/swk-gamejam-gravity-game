using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnDebree : MonoBehaviour
{
    [SerializeField] private bool spawn = true;
    [SerializeField] private GameObject[] debrees;
    [SerializeField] private Collider2D[] collisions;

    void Start()
    {
        StartCoroutine(timerDebree());
    }
    private void spawnDebree()
    {
        int i = Random.Range(0, debrees.Length - 1);
        int j = Random.Range(0, collisions.Length - 1);
        Instantiate(debrees[i], RandomPointInBounds(collisions[j].bounds), Quaternion.identity, transform);
        timerDebree();
    }
    private static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            -10
        );
    }

    IEnumerator timerDebree()
    {
        while (spawn)
        {   
            spawnDebree();
            yield return new WaitForSeconds(0.75f);
        }
    }
}
