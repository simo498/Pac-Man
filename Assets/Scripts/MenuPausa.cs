using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public static bool Menu = false;
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
           
            PausaMenu();
        }

        if(Input.GetKeyDown(KeyCode.Escape)&& Menu==true)
        {
            ContinueGame();
        }
    }

    private void PausaMenu()
    {
        Time.timeScale=0f;
        Menu = true;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        Menu = false;
    }
}
