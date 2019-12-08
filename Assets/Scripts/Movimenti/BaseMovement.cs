using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BaseMovement : MonoBehaviour
{
    public float Speed;
    private List<RaycastHit2D> hits;

    public BaseMovement()
    {
        hits = new List<RaycastHit2D>(100);
    }

    public virtual void Move(Vector2 direction)
    {
        transform.localPosition += (Vector3)(direction * Speed) * Time.deltaTime;
    }

    public virtual bool IsValid(Vector2 direction, string saltaOgg)
    {
        /*
        Problemi:
        - PacMan si blocca quando tocca un muro perche' non trova palline nei dintorni
        - Quando gira, la posizione di PacMan dev'essere corretta per non farlo scivolare su
          alcuni spigoli
        */

        bool ret = false;
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

        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i].collider.CompareTag("Wall"))
            {
                ret = false;
                break;
            }

            else if (hits[i].collider.CompareTag("PacManfood") ||
                     hits[i].collider.CompareTag("PacManSfood"))
            {
                /* Vengono escluse le palline all'interno del collider di PacMan che 
                   non fanno funzionare correttamente il programma */
                bool trovato = false;
                for (int i2 = 0; i2 < i - 1; i2++)
                {
                    if (hits[i2].collider.CompareTag("Player"))
                    {
                        ret = true;
                        trovato = true;
                        break;
                    }
                }
                if (trovato == true)
                    break;
                else continue;
            }

            else if (hits[i].collider.CompareTag(saltaOgg))
                continue;
        }

        hits.Clear();
        return ret;
    }
}