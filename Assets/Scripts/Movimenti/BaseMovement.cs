using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    public float Speed;
    public virtual void Move(Vector2 direction)
    {
        transform.localPosition += (Vector3)(direction * Speed) * Time.deltaTime;
    }

    public virtual bool IsValid(Vector2 direction)
    {
        Vector2 pos = (Vector2)transform.position;
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
}

