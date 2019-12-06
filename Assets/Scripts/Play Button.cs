using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public void PlayOnClick()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
       Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
}
