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
                //PACMAN MUORE
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
            UnityEngine.Debug.Log("SUPER POWER FINE");
            //I FANTASMI TORNANO NORMALI
        }
    }
}

