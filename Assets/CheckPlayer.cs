using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    public GameObject WinTab;
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameHandler.Win = true;
            WinTab.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
