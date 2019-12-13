using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BaseMovement : MonoBehaviour
{
    public float Speed;
    private List<RaycastHit2D> hits;
    protected bool incastrato = false;

    public BaseMovement()
    {
        hits = new List<RaycastHit2D>(100);
    }

    public virtual void Move(Vector2 direction, Vector2? _vector)
    {
        if (_vector.HasValue == true)
        {

        }
        transform.localPosition += (Vector3)(direction * Speed) * Time.deltaTime;

        //Se l'oggetto e' in prossimita' di un muro, "incastrato" diventa true, senno' false
        var ray = Physics2D.Linecast(
            (Vector2)this.transform.position,
            (Vector2)this.transform.position + direction);

        if (ray.collider.CompareTag("Wall") == true)
        {
            this.incastrato = true;
        }
        else this.incastrato = false;
    }

    public virtual bool IsValid(Vector2 direction, string saltaOgg)
    {
        /*
        Problemi:
        - Bisogna aggiustare i collider in modo da non far sbattere PacMan quando gira agli spigoli
        - PacMan si blocca quando tocca un muro
        */

        bool ret = false;
        Vector2 pos = transform.position;
        Vector2 linecastVector;

        if (this.incastrato == true)
        {
            if (direction == Vector2.left)
                pos.x += 0.2f;
            else if (direction == Vector2.right)
                pos.x -= 0.2f;
            else if (direction == Vector2.up)
                pos.y -= 0.2f;
            else if (direction == Vector2.down)
                pos.y += 0.2f;
        }

        if (direction == Vector2.left)
            linecastVector = pos + new Vector2(-0.3f, 0.0f);
        else if (direction == Vector2.right)
            linecastVector = pos + new Vector2(0.3f, 0.0f);
        else if (direction == Vector2.up)
            linecastVector = pos + new Vector2(0.0f, 0.3f);
        else if (direction == Vector2.down)
            linecastVector = pos + new Vector2(0.0f, -0.3f);
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

    public static Vector2 Inverso(Vector2 dir)
    {
        if (dir == Vector2.right)
            return Vector2.left;
        else if (dir == Vector2.left)
            return Vector2.right;
        else if (dir == Vector2.up)
            return Vector2.down;
        else if (dir == Vector2.down)
            return Vector2.up;

        else return Vector2.zero;
    }
}