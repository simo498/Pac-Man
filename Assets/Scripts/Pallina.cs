using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallina : MonoBehaviour
{
    Pallina cibo;

    void Start()
    {
        if(gameObject.GetComponent<Renderer>().enabled == false || gameObject.GetComponent<Collider>().enabled == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
