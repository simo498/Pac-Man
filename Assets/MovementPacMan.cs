using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPacMan : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float speedPacMan = 20.0F;
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
        if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A)) 
        {
            direzione = Vector2.left;
            transform.localRotation = Quaternion.Euler(0, 0, -180);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            direzione = Vector2.right;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            direzione =  Vector2.up;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            direzione = Vector2.down;
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }

    void Move()
    {
        transform.localPosition += (Vector3)(direzione * speedPacMan) * Time.deltaTime;
    }
}
