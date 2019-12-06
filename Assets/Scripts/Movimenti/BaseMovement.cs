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

        Physics2D.Linecast(pos, linecastVector, filter, hits);
        var hit = hits[1];
        if (hit.collider != null && (
                hit.collider.CompareTag("Wall") ||
                hit.collider.CompareTag("orange") ||
                hit.collider.CompareTag("blue")))
            return false;

        else return true;
    }
}

