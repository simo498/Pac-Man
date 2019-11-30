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
        Move();
    }

    void Movement()
    { 
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direzione = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direzione = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direzione =  Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direzione = Vector2.down;
        }
    }

    void Move()
    {
        transform.localPosition += (Vector3)(direzione * speedPacMan) * Time.deltaTime;
    }
}
