﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPacMan : MonoBehaviour
{
    //ROTAZIONE IN GRADI
    const int UP_DIRECTION = 90;
    const int DOWN_DIRECTION = -90;
    const int LEFT_DIRECTION = -180;
    const int RIGHT_DIRECTION = 0;
    public bool svolta=false;
    
    Vector2 NextDirection;
    Collider2D pacManCollider;
    Vector2 Direction = Vector2.zero;
    public bool AttivaMovimento = true;
    public float PacManSpeed;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Turn" || other.gameObject.tag == "TurnFantasmi")
        {
            AttivaMovimento = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Turn" || other.gameObject.tag == "TurnFantasmi")
        {
            AttivaMovimento = false;
        }
    }
    //Muove PacMan in base al vettore passato come parametro
    void Move(Vector2 direction)
    {
        if (direction == Vector2.up)
            Rotate(UP_DIRECTION);
        else if (direction == Vector2.down)
            Rotate(DOWN_DIRECTION);
        else if (direction == Vector2.left)
            Rotate(LEFT_DIRECTION);
        else if (direction == Vector2.right)
            Rotate(RIGHT_DIRECTION);

        transform.localPosition += (Vector3)(direction * PacManSpeed) * Time.deltaTime;
    }

    //Ottiene l'input da (WASD o freccette) e restituisce il vettore in cui PacMan dovrebbe
    //svoltare, o un vettore nullo se non viene dato alcun input
    Vector2 GetInput()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && svolta == true)
        {
            if (svolta == true)
            {
                return Vector2.left;
            }
            else return Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (svolta == true)
            {
                return Vector2.right;
            }
            else return Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            if (svolta == true)
            {
                return Vector2.up;
            }
            else return Vector2.zero; 
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            if (svolta == true)
            {
                return Vector2.down;
            }
            else return Vector2.zero; 

        else return Vector2.zero;
=======
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                AttivaMovimento = false;
                return Vector2.left;
            }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                AttivaMovimento = false;
                return Vector2.right;
            }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                AttivaMovimento = false;
                return Vector2.up;
            }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                AttivaMovimento = false;
                return Vector2.down;
            }
        else
            return Vector2.zero;
>>>>>>> Stashed changes
    }

    void Rotate(int rotation)
    {
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    /*bool IsValid(Vector2 direction)
    {
        Vector2 pos = transform.position;
        Vector2 linecastVector = Vector2.zero;
        if (direction == Vector2.left)
            linecastVector = pos + new Vector2(-0.4f, 0.0f);
        else if (direction == Vector2.right)
            linecastVector = pos + new Vector2(0.4f, 0.0f);
        else if (direction == Vector2.up)
            linecastVector = pos + new Vector2(0.0f, 0.4f);
        else if (direction == Vector2.down)
            linecastVector = pos + new Vector2(0.0f, -0.4f);
        else return false;

        var hit = Physics2D.Linecast(linecastVector, pos);
<<<<<<< Updated upstream
        if (hit.collider == pacManCollider || hit.collider.tag == "PacManfood")
=======
        if (hit.collider == pacManCollider || hit.collider.tag == "PacManfood" ||
            hit.collider.tag == "PacManSfood" || hit.collider.tag == "Turn")
>>>>>>> Stashed changes
            return true;
        else return false;
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Incrocio")
        {
            svolta = true;
        }
    }

        void Start()
    {
        pacManCollider = GetComponent<Collider2D>();
        NextDirection = Vector2.zero;
        AttivaMovimento = true;
    }

    void FixedUpdate()
    {
        if (AttivaMovimento==true)
        {
<<<<<<< Updated upstream
            svolta = false;
            NextDirection = input;
        }

        if (NextDirection != Vector2.zero )
        {
            svolta = false;
            Direction = NextDirection;
            NextDirection = Vector2.zero;
        }
=======
            var input = GetInput();
            if (input != Vector2.zero)
            {
                NextDirection = input;
            }
        }
        
        if (NextDirection != Vector2.zero && IsValid(NextDirection))
        {
             Direction = NextDirection;
             NextDirection = Vector2.zero;
         }
        
>>>>>>> Stashed changes
        Move(Direction);
    }
}
