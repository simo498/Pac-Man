using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManFood : MonoBehaviour
{
    int score;
    public Text ScoreText;
    public GameObject Player;
    public GameObject Food;

    void OnTriggerEnter2D(Collider2D other)
    {             
         if (other.gameObject.tag == "PacManfood")
         {
              score = score + 1;
              Debug.Log("Score = " + score);
              ScoreText.text= "Score = " + score.ToString();
         }      
     }
}
