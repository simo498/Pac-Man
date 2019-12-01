using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPacMan : MonoBehaviour
{ 
    //ROTAZIONE IN GRADI
    const int UP_DIRECTION = 90;
    const int DOWN_DIRECTION = -90;
    const int LEFT_DIRECTION = -180;
    const int RIGHT_DIRECTION = 0;

    Vector2 Direction = Vector2.zero;

    void _move(Vector2 direction)
    {
        transform.localPosition += (Vector3)(direction * speedPacMan) * Time.deltaTime;
    }

    Vector2 _getInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            return Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            return Vector2.right;
        else if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
            return Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
            return Vector2.down;

        else return Vector2.zero;
    }

    void _rotate(int rotation)
    {
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    void _isValid(Vector2 direction)
    {

    }







    //CODICE VECCHIO
    Rigidbody2D pacManRB;
    Collider2D collider;
    public float speedPacMan = 20.0F;
    public Vector2 direzione = Vector2.zero;
    void Start()
    {
        pacManRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }


    /*Ottiene l'input (freccette o WASD), cambia la direzione del vettore a cui
         * punta Pac-Man e muove lo sprite*/
    void GetInput()
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
        Move();
    }

    //Modifica la posizione di pacman in base alla direzione del vettore
    void Move()
    {
        transform.localPosition += (Vector3)(direzione * speedPacMan) * Time.deltaTime;
    }
}