using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : MonoBehaviour
{

    private Transform destinazione;
    public bool isOrange;
    float DistMin = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOrange == false)
        {
            destinazione = GameObject.FindGameObjectWithTag("orange").GetComponent<Transform>();
        }
        else
        {
            destinazione = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Vector2.Distance(transform.position,other.transform.position) > DistMin && (other.gameObject.tag == "Player") )
        { 
            other.transform.position = new Vector2(destinazione.position.x, destinazione.position.y);         
        }
        
    }
}
