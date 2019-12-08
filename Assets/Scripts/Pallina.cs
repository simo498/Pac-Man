using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallina : MonoBehaviour
{
    public bool attivo = true;

    void Start()
    {
        if(gameObject.GetComponent<Renderer>().enabled == false || attivo == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().gameObject.SetActive(true);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.SetActive(false);
            attivo = false;
        }
    }
}
