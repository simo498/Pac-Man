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
    
    Vector2 NextDirection;
    Vector2 Direction = Vector2.zero;

    public float PacManSpeed;

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

    void Rotate(int rotation)
    {
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    bool IsValid(Vector2 direction)
    {
        Vector2 pos = transform.position;
        Vector2 linecastVector;
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
        if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("orange") || hit.collider.CompareTag("blue"))
            return false;
        else return true;
    }

    void Start()
    {
        NextDirection = Vector2.left;
    }

    void Update()
    {
        var input = GetInput();
        if (input != Vector2.zero)
        {
            NextDirection = input;
        }

        if (NextDirection != Vector2.zero && IsValid(NextDirection))
        {
            Direction = NextDirection;
            NextDirection = Vector2.zero;
        }
        Move(Direction);
    }
}
