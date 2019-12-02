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

    /*readonly Vector2[] UP_DOWN_VECTOR = new Vector2[2] { Vector2.left, Vector2.right };
    readonly Vector2[] LEFT_RIGHT_VECTOR = new Vector2[2] { Vector2.up, Vector2.down };*/

    Vector2 Direction = Vector2.zero;

    //Muove PacMan in base al vettore passato come parametro
    void _move(Vector2 direction)
    {
        if (direction == Vector2.up)
            _rotate(UP_DIRECTION);
        else if (direction == Vector2.down)
            _rotate(DOWN_DIRECTION);
        else if (direction == Vector2.left)
            _rotate(LEFT_DIRECTION);
        else if (direction == Vector2.right)
            _rotate(RIGHT_DIRECTION);

        transform.localPosition += (Vector3)(direction * PacManSpeed) * Time.deltaTime;
    }

    //Ottiene l'input da (WASD o freccette) e restituisce il vettore in cui PacMan dovrebbe
    //svoltare, o un vettore nullo se non viene dato alcun input
    Vector2 _getInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            return Vector2.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            return Vector2.right;
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            return Vector2.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            return Vector2.down;

        else return Vector2.zero;
    }

    void _rotate(int rotation)
    {
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    bool _isValid(Vector2 direction)
    {
        var hit = Physics2D.Linecast((Vector2)transform.position + direction,
                                    (Vector2)transform.position);
        if (hit.collider == _pacManCollider)
            return true;
        else return false;
    }


    void _update()
    {
        var input = _getInput();
        if (input != Vector2.zero)
        {
            _nextDirection = input;
        }

        if (_nextDirection != Vector2.zero && _isValid(_nextDirection))
        {
            Direction = _nextDirection;
            _nextDirection = Vector2.zero;
        }
        _move(Direction);
    }




    //CODICE VECCHIO
    Rigidbody2D pacManRB;
    Collider2D _pacManCollider;
    public float PacManSpeed = 10.0F;
    public Vector2 direzione = Vector2.left;
    public Vector2 _nextDirection = Vector2.zero;
    void Start()
    {
        pacManRB = GetComponent<Rigidbody2D>();
        _pacManCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        //GetInput();
        _update();
    }


    /*Ottiene l'input (freccette o WASD), cambia la direzione del vettore a cui
         * punta Pac-Man e muove lo sprite*/
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            direzione = Vector2.left;
            transform.localRotation = Quaternion.Euler(0, 0, -180);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            direzione = Vector2.right;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            direzione = Vector2.up;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            direzione = Vector2.down;
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        Move();
    }

    //Modifica la posizione di pacman in base alla direzione del vettore
    void Move()
    {
        transform.localPosition += (Vector3)(direzione * PacManSpeed) * Time.deltaTime;
    }
}