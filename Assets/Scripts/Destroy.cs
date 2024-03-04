using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Destroy : MonoBehaviour
{

    public int points = 0;
    public TextMeshProUGUI guiScore;
    public int complete = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        guiScore.text = "Score: "+ points.ToString();

        if (points == complete)
        {
           Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
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


