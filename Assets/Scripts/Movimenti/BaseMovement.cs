using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class BaseMovement : MonoBehaviour
{
    public float Speed;
    private List<RaycastHit2D> hits;
    protected bool bloccato = false;

    public BaseMovement()
    {
        hits = new List<RaycastHit2D>(100);
    }

    public virtual void Move(Vector2 direction)
    {

        /*CODICE NON TERMINATO
         * |---------------------------------------------------------------------------------|
          * Linecast deve salvare nella variabile "rayHits" i collider che il raggio ha colpito
              con il ContactFilter2D settato su NOFILTER e scrivere il codice per evitare che il raggio
              che dovrebbe controllare la collisione con il muro eviti lo sprite di PacMan e potenziali
              ostacoli (es. collider dei pellet)
              
            * Accedendo alla posizione 1 dell'array "rayHits" si dovrebbe evitare lo sprite di PacMan e colpire
               il muro.

            * In alternativa (se sono presenti altri ostacoli tra pacman e il muro) usare un loop
               che scarti tutti i collider con tag diverso da "Wall". Una volta trovato il muro impostare
        *|----------------------------------------------------------------------------------------------------------|
        Creare un campo nella classe per mantenere in memoria il valore bool dell'eventuale blocco di 
        PacMan e se il Linecast colpisce il muro a una distanza ravvicinata dalla sua origine (PacMan)
        allora settare quella variabile su true, senno' su false, e controllare ogni volta che viene
        richiamato il metodo di spostamento se PacMan e' incastrato. Se lo e', spostarlo di una somma
        minima nella direzione OPPOSTA a quella a cui e' rivolto attualmente (che dovrebbe essere la quella
        che punta al muro) e riprovare a eseguire il check di valitita' per "nextDirection" richiesta 
        dall'utente. In alternativa fare un loop che sposta PacMan di valori ancora piu' bassi fino a raggiungere
        la direzione desiderata per evitare di spostarlo troppo in avanti o in indietro (il loop si ferma da solo
        se entro un tot. di distanza non viene trovata alcuna strada percorribile)
        *|-----------------------------------------------------------------------------------------------------------------------------|
        Dividere tutto cio' in classi che gestiscono un singolo componente di PacMan (es. Input, Movimento,
        Collisioni, ecc...) che non contengono funzioni che vanno in loop, e una che gestisce l'intero gioco
        (Main per esempio)
        *|----------------------------------------------------------------------------------------------------------------------------|

         */

        //codice per sbloccare pacman nel caso si trovi incastrato nel muro
        if (bloccato)
        {
            var inverse = Inverso(direction, 0.4f);
            this.transform.localPosition += (Vector3)inverse;
        }

        transform.localPosition += (Vector3)(direction * Speed) * Time.deltaTime;
        var rayHits = new RaycastHit2D[4];
        var contactFilter = new ContactFilter2D();
        contactFilter.NoFilter();

        //Se l'oggetto e' in prossimita' di un muro, "incastrato" diventa true, senno' false
        Physics2D.Linecast(
            (Vector2)this.transform.position,
            (Vector2)this.transform.position + direction,
            contactFilter,
            rayHits
            );

        //Ignora il collider di PacMan accedendo a quello successivo
        if (rayHits[1].collider == null)
            return;
        if (rayHits[1].collider.CompareTag("Wall") == true)
        {
            if (this.bloccato == false)
                UnityEngine.Debug.Log("INCASTRATO TRUE");// DEBUG
            this.bloccato = true;
        }
        else
        {
            if (this.bloccato == true)
                UnityEngine.Debug.Log("INCASTRATO FALSE");// DEBUG
            this.bloccato = false;
        }
    }

    public virtual bool IsValid(Vector2 direction,
        string saltaOgg,
        Vector2? position = null)
    {
        bool ret = false;
        Vector2 pos;
        if (position.HasValue)
            pos = position.Value;
        else pos = transform.position;
        Vector2 linecastVector;

        if (this.bloccato == true)
        {
            /*CODICE NON FUNZIONANTE, RIVEDERE
             * if (direction == Vector2.left)
                pos.x += 0.2f;
            else if (direction == Vector2.right)
                pos.x -= 0.2f;
            else if (direction == Vector2.up)
                pos.y -= 0.2f;
            else if (direction == Vector2.down)
                pos.y += 0.2f; */
            transform.localPosition += (Vector3)Inverso(
                transform.GetComponent<PacManMovement>().Direction, 0.2f);
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

    /*Restituisce il vettore (Vector2) inverso a quello specificato
     *
     * float dist: Se modificato crea un vettore opposto a quello
     *             specificato, ma con modulo variabile
     */
    public static Vector2 Inverso(Vector2 dir, float dist = 1.0f)
    {
        float posX = 0;
        float posY = 0;

        //Valore assoluto del parametro "dist"
        float absDist = System.Math.Abs(dist);

        if (dir == Vector2.right)
            posX = -absDist; //Vector2(-Dist, 0)
        else if (dir == Vector2.left)
            posX = absDist; //Vector2(+Dist, 0)
        else if (dir == Vector2.up)
            posY = -absDist; //Vector2(0, -Dist)
        else if (dir == Vector2.down)
            posY = absDist; //Vector2(0, +Dist)

        return new Vector2(posX, posY);
    }
}