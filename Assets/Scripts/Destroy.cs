using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{

    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points == 200)
        {
            SceneManager.LoadScene("AngryVirus1");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "Person")
        {
            //Create a reference to the man
            GameObject person = collision.gameObject;

            //Destroy the man
            Destroy(person);

            //Debug the new Total
            Debug.Log("Person dead");

            points += 200;
            Debug.Log("Points: " + points);
        }

         if(collision.collider.tag == "virus")
        {
            //Create a reference to the collectable
            GameObject virus = collision.gameObject;

            //Destroy the man
            Destroy(virus);

        }
    }
}


