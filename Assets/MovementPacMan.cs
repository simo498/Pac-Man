using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPacMan : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float speedPacMan = 4.0F;
    public Vector2 direzione = Vector2.zero;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Movement();        
    }

    void Movement()
    { 
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           Input.GetAxisRaw("Horizontal");
        }
        /*else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direzione = Vector2.Right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direzione =  Vector2.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direzione = Vector2.Down;
        }*/
    }


}
