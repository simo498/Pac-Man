using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManFood : MonoBehaviour
{
    public bool isFood;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        for(int i = 0; i < 10; i++ )
        { 
            if (other.gameObject.tag == "PacManfood")
            {
                score = score + 1;
                Debug.Log("Score = " + score);
            }
        }
    }
}
