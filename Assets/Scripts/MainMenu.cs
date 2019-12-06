using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Scena 1");
        SceneManager.LoadScene("Livello1");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Livello1"));
    }
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
