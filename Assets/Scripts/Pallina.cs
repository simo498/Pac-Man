using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallina : MonoBehaviour
{
    public bool attivo = true;
    Collider2D collider;

    void Start()
    {
        if(gameObject.GetComponent<Renderer>().enabled == false || attivo == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            collider.gameObject.SetActive(true);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.SetActive(false);
            attivo = false;
        }
    }
}
