using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandling : MonoBehaviour
{

    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnGoTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void OnTutorial()
    {
        return;
    }

    public void OnEnd()
    {
        Application.Quit();
    }

}
