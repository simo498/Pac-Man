using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : BaseMovement
{
    Vector2 NextDirection;
    Vector2 Direction = Vector2.zero;
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

    public Vector2 GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            return Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D))
            return Vector2.right;
        else if (Input.GetKeyDown(KeyCode.W))
            return Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            return Vector2.down;

        else return Vector2.zero;
    }
    public override bool IsValid(Vector2 direction)
    {
        var hits = new RaycastHit2D[10];
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

        var filter = new ContactFilter2D(); filter.NoFilter();

        int index = 1;
        Physics2D.Linecast(pos, linecastVector, filter, hits);
        RaycastHit2D hit = hits[index];

        while (hit.collider.CompareTag("PacManfood") ||
               hit.collider.CompareTag("PacManSfood") ||
               hit.collider.CompareTag("Ghost"))
        {
               index++;
            hit = hits[index];
        }

        if (hit.collider != null && (
                hit.collider.CompareTag("Wall") ||
                hit.collider.CompareTag("orange") ||
                hit.collider.CompareTag("blue")))
            return false;

        else return true;
    }
}
