using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour
{
    //dichiatazione variabili 
    private Transform destinazione;
    public bool isOrange;
    float DistMin = 0.3f;    

    void Start()
    {
        //controllo portali e inserimento nelle varibili della sua posizione 
        if (isOrange == false)
        {
            destinazione = GameObject.FindGameObjectWithTag("orange").GetComponent<Transform>();
        }
        else
        {
            destinazione = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
        }
    }
    void Update()
    { }
    //metodo che riconosce la collisione tra il player e il portale 
    void OnTriggerEnter2D(Collider2D other)
    {
       if(Vector2.Distance(transform.position, other.transform.position) > 0.1f)
       {           
            other.transform.position = new Vector2(destinazione.position.x, destinazione.position.y);
       }                       
    }
    

}