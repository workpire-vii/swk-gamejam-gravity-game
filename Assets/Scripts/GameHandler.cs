using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool Pause;
    public static bool Lose;
    public static bool Win;

    [SerializeField] private GameObject pauseTab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Pause = true;
                pauseTab.SetActive(false);
                Time.timeScale = 1;
            }
            else if (Time.timeScale == 1)
            {
                Pause = false;
                pauseTab.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
}
