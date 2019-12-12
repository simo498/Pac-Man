using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Collisioni : MonoBehaviour
{
    int score;
    bool superPower = false;
    Stopwatch timer;
    public Text ScoreText;
    public GameObject Player;
    public GameObject Food;
    public GameObject[] Fantasmi;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PacManfood")
        {
            score += 5;
            //UnityEngine.Debug.Log("Score = " + score);
            ScoreText.text = "Score: " + score.ToString();
        }

        else if (other.gameObject.tag == "Ghost")
        {
            if (superPower == true)
            {
                //CODICE MORTE FANTASMA
                other.gameObject.GetComponent<Renderer>().enabled = false;
                other.gameObject.SetActive(false);
            }
            else
            {
<<<<<<< Updated upstream
                //PACMAN MUORE
=======
                if (vite > 0)
                {
                    transform.localPosition = new Vector3(18.2f, 9.35f, 0.0f);
                    vite--;
                    superPower = false;
                    var obj = GameObject.Find("pacman_sprite");
                    var scriptableObj = obj.GetComponent<PacManMovement>();
                    scriptableObj.Direction = Vector2.zero;
                    scriptableObj.NextDirection = Vector2.left;
                  
                }

                else
                {
                    GetComponent<Renderer>().enabled = false;
                    gameObject.SetActive(false);
                }
>>>>>>> Stashed changes
            }

        }

        else if (other.gameObject.tag == "PacManSfood")
        {
            superPower = true;
            timer = new Stopwatch();
            timer.Start();
            UnityEngine.Debug.Log("SUPER POWER INIZIO");
            //CODICE PER I FANTASMI
        }
    }

    void FixedUpdate()
    {
        if (superPower == true && timer.ElapsedMilliseconds > 7000)
        {
            superPower = false;
            timer.Stop();
            timer.Reset();
            UnityEngine.Debug.Log("SUPER POWER FINE");
            //I FANTASMI TORNANO NORMALI
        }
    }
}

