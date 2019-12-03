using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManFood : MonoBehaviour
{
    public bool isFood;
    int score;

    public GameObject Player;
    public GameObject Food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {             
         if (other.gameObject.tag == "PacManfood")
         {
              score = score + 1;
              Debug.Log("Score = " + score);
         }      
     }
}
