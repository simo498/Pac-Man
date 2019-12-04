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
    public uint DURATA_POTERE_MS;
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
            ScoreText.text = "Score: " + score.ToString();
        }

        else if (other.gameObject.tag == "Ghost")
        {
            if (superPower == true)
            {
                other.gameObject.GetComponent<Renderer>().enabled = false;
                other.gameObject.SetActive(false);
            }

            else
            {
                GetComponent<Renderer>().enabled = false;
                gameObject.SetActive(false);
            }

        }

        else if (other.gameObject.tag == "PacManSfood")
        {
            superPower = true;
            timer = new Stopwatch();
            timer.Start();
        }
    }

    void FixedUpdate()
    {
        if (superPower == true && timer.ElapsedMilliseconds >= DURATA_POTERE_MS)
        {
            superPower = false;
            timer.Stop();
        }
    }
}