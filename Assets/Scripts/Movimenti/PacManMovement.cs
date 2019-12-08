using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PacManMovement : BaseMovement
{
    //ROTAZIONE IN GRADI
    const int UP_DIRECTION = 90;
    const int DOWN_DIRECTION = -90;
    const int LEFT_DIRECTION = -180;
    const int RIGHT_DIRECTION = 0;

    public Vector2 NextDirection;
    public Vector2 Direction = Vector2.zero;

    //Muove PacMan in base al vettore passato come parametro
    public override void Move(Vector2 direction)
    {
        if (direction == Vector2.up)
            Rotate(UP_DIRECTION);
        else if (direction == Vector2.down)
            Rotate(DOWN_DIRECTION);
        else if (direction == Vector2.left)
            Rotate(LEFT_DIRECTION);
        else if (direction == Vector2.right)
            Rotate(RIGHT_DIRECTION);

        base.Move(direction);
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

        if (NextDirection != Vector2.zero && IsValid(NextDirection, "Ghost"))
        {
            Direction = NextDirection;
            NextDirection = Vector2.zero;
        }
        Move(Direction);
    }
}
