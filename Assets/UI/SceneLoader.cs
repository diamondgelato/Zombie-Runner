using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Reload () {
        // int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame () {
        Debug.Log("bye bye");
        Time.timeScale = 1;
        Application.Quit();
    }
}
